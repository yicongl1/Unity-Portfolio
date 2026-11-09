# 02. 飞龙射击

竖版 2D 射击小游戏。玩家在屏幕下方移动并连续射击，普通敌人随机生成；Boss 会以 10–20 秒的间隔出现，先下降到指定高度，再左右巡逻。

- Unity 版本：2021.3.5f1c1
- 渲染管线：Built-in
- 输入：旧版 Input Manager

## 场景

| 场景 | Build Index | 作用 |
|------|-------------|------|
| `Assets/Scene/UI.unity` | 0 | 开始界面，提供开始与退出 |
| `Assets/Scene/Game.unity` | 1 | 战斗场景 |

## 操作

- `WASD` / 方向键：移动
- `J`：射击（按住连发，受冷却时间限制）

## 代码结构

| 脚本 | 作用 |
|------|------|
| `PlayerCtrl.cs` | 读取输入，驱动移动与射击 |
| `PlayerChar.cs` | 玩家移动、边界限制、子弹生成、被击中死亡 |
| `Bullet.cs` | 子弹向上移动，命中后生成爆炸并销毁 |
| `Enemy.cs` | 普通敌人：向下移动、受击闪红、血量与死亡爆炸 |
| `Guard.cs` | Boss：先下移到指定高度，再左右巡逻 |
| `Spawner.cs` | 协程按随机间隔、随机位置生成随机怪物 |
| `UICtrl.cs` | 开始游戏、退出 |
| `CamRatioAdapter.cs` | 根据屏幕宽高比调整正交相机尺寸 |
| `BGMove.cs` | 滚动背景材质的 UV |
| `Border.cs` | 可序列化的移动边界 |
| `AnimEvent.cs` | 动画事件中销毁对象 |
| `DelayDestroy.cs` | 延迟销毁特效 |

## 实现要点

- **刷怪**：`Spawner` 用 `while (true)` 协程，每次 `Random.Range(minTime, maxTime)` 等待后生成怪物，位置在屏幕宽度范围内随机。
- **射击冷却**：`PlayerChar.Fire` 用 `lastFireTime + fireCD` 限制射速，避免按帧生成子弹。
- **Boss 状态机**：`Guard` 用 `enum State { Down, LeftRight }` 控制「先下移、后巡逻」两个阶段。
- **屏幕适配**：`CamRatioAdapter` 保持「宽 × Size」不变，根据当前宽高比反推正交相机 `orthographicSize`，让不同比例的屏幕看到相近的横向范围。
- **受击反馈**：敌人被击中后用 `SpriteRenderer.color` 闪红，`changeColorTime` 到点后恢复白色。

## 备注

- 开始界面的「开始游戏」按钮直接加载战斗场景（Build Index 1），退出按钮关闭程序。

## 第三方内容

角色、怪物、子弹、音效等美术资源来自学习期间使用的 2D 素材包，版权归原作者。详见仓库根目录的授权说明。
