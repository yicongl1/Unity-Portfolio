# 01. 滚动球街机合集

一个 Unity 工程里包含 3 个 3D 小游戏和 1 个第一人称控制器演示，通过主菜单进入。这个项目主要用来练习场景切换、物理、UI 和相机。

- Unity 版本：2021.3.5f1c1
- 渲染管线：Built-in
- 输入：旧版 Input Manager

## 场景

| 场景 | 作用 |
|------|------|
| `Assets/UIfront.unity` | 启动场景，异步加载 UI 菜单 |
| `Assets/UI.unity` | 主菜单，选择三个小游戏 |
| `Assets/Rolling Ball.unity` | 滚球闯关 |
| `Assets/Maze.unity` | 迷宫滚球 |
| `Assets/PullTheBox.unity` | 拉箱子解谜 |
| `Assets/RollingBall/ForceField.unity` | 学习过程中的额外测试场景，未加入 Build Settings |

Build Settings 顺序：`UIfront` → `UI` → `Rolling Ball` → `Maze` → `PullTheBox`。

## 操作

**Rolling Ball**

- `A / D` 或左右方向键：左右移动
- `W / S` 或上下方向键：前进 / 后退（背景音乐音调会随之变化）
- `Space`：跳跃
- `C`：作弊键，直接把球传送到终点附近

**Maze**

- `WASD` / 方向键：给球施加力
- `Esc`：打开 / 关闭暂停面板

**PullTheBox**

- `WASD`：移动角色
- 鼠标：控制角色朝向
- 鼠标左键：伸出手臂 / 抓取箱子
- 鼠标右键：放下箱子

目标是把箱子送到同色灯下，所有灯亮起即通关。

**Mini First Person Controller**

- `WASD`：移动
- `Shift`：奔跑
- `Space`：跳跃
- `Ctrl`：下蹲
- 鼠标：视角
- 滚轮：缩放

## 代码结构

```text
Assets/
├─ RollingBall/C#/
│  ├─ BallMovement.cs      球的移动、跳跃、作弊、掉出平台判负
│  ├─ GM.cs                胜负面板、重开、返回菜单
│  ├─ Coin.cs              金币拾取
│  ├─ Endline.cs           到达终点
│  ├─ Box.cs               碰到障碍物判负
│  ├─ follow.cs            相机跟随与左右倾斜
│  ├─ SceneLoad.cs         主菜单按钮逻辑
│  ├─ AudioControl.cs      暂停时控制 BGM
│  └─ movingball.cs        场景中往返移动的球
├─ Maze/C#/
│  ├─ Ball.cs              力驱动移动
│  ├─ GameMode.cs          开始 / 暂停 / 退出 / 重开
│  ├─ CoinExit.cs          出口触发器
│  ├─ CoinReset.cs         重置关卡
│  └─ UIfront.cs           异步进入 UI 场景
├─ PullTheBox/C#/
│  ├─ PlayerController.cs  输入汇总
│  ├─ Playertask.cs        移动、边界限制、瞄准、伸缩手臂、抓放箱子
│  ├─ PullBox.cs           箱子寻路与朝向
│  ├─ Lamp.cs              同色灯亮起判定
│  ├─ LightManage.cs       全部灯亮起即胜利
│  ├─ ColorManage.cs       颜色映射
│  └─ CameraFollow.cs      相机跟随
└─ Mini First Person Controller/Scripts/   第三方示例控制器
```

## 实现要点

- **直接改速度 vs 施加力**：Rolling Ball 用 `Rigidbody.velocity` 保持稳定的前进速度；Maze 用 `AddForce` 让球在物理作用下滚动，手感不同。
- **暂停**：通过 `Time.timeScale = 0` 冻结游戏，同时用 `AudioControl` 关闭 BGM。
- **场景串联**：`SceneLoad` 负责主菜单跳转，`GM` 负责单个小游戏内的重开和返回。
- **拉箱子**：`Playertask` 用摄像机射线把鼠标位置转换成角色朝向，再用触发器检测可抓取的箱子，通过改变手臂 `localScale.z` 做伸缩动画。
- **相机**：Rolling Ball 用固定偏移 + 左右倾斜；PullTheBox 用 `Quaternion.Lerp` 平滑看向角色。

## 备注

- 主菜单的「拉箱子」入口依赖 Build Settings 中的 `PullTheBox` 场景，工程里已经配置好。
- 迷宫场景按 `Esc` 可以暂停 / 继续；重置触发器会重新加载迷宫。

## 第三方内容

`Mini First Person Controller` 为 Unity Asset Store 的示例控制器，版权归原作者。天空盒、贴图、音频等素材同样来自第三方资源，详见仓库根目录的授权说明。
