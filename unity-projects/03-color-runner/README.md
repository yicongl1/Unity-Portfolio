# 03. 变色跑酷

3D 无限跑酷小游戏。角色自动向前跑，玩家只需要控制跳跃和红绿换色，颜色与平台不匹配就会死亡。

- Unity 版本：2021.3.5f1c1
- 渲染管线：Built-in
- 输入：旧版 Input Manager

## 场景

| 场景 | Build Index | 作用 |
|------|-------------|------|
| `Assets/Scenes/start.unity` | 0 | 开始界面 |
| `Assets/Scenes/run.unity` | 1 | 跑酷主场景 |

## 操作

- `Space`：跳跃
- `J`：在红色和绿色之间切换

红色角色只能站在红色平台上，绿色角色只能站在绿色平台上。踩到异色平台会立即死亡。

## 代码结构

| 脚本 | 作用 |
|------|------|
| `PlayerCtrl.cs` | 读取跳跃 / 换色输入，在 `FixedUpdate` 中交给角色处理 |
| `PlayerChar.cs` | 自动前进、跳跃、地面检测、换色、碰撞死亡、死亡粒子 |
| `FollowCam.cs` | 相机平滑跟随 |
| `GameMode.cs` | 单例入口，控制开始、重开、退出与 Game Over 面板 |

## 实现要点

- **自动前进**：`PlayerChar.Move` 每帧把 `Rigidbody.velocity.z` 固定为 `speed`，玩家只需要处理跳跃。
- **跳跃与落地**：落地时把 `jumpCount` 清零，`jumpCount < 1` 保证只能跳一次；`isGround` 同步给 Animator。
- **颜色规则**：平台通过 `Green` / `Red` 标签区分；`OnCollisionStay` 中比较角色当前颜色与平台标签，不一致就调用 `PlayerDie`。
- **死亡表现**：按当前颜色选择红/绿两种粒子预制体，隐藏角色，1 秒后弹出 Game Over 面板。
- **相机**：`Vector3.Lerp` 让相机以固定偏移平滑跟随，避免硬切。

## 整理时的修改

- `GameMode.Start` 增加了空值判断。该脚本同时存在于开始场景和跑酷场景，而开始场景没有 `GameOverPanel`，原写法会在开始界面抛 `NullReferenceException`。
- 补充了脚本文件末尾换行与尾随空格清理。

## 第三方内容

角色模型、动画、场景素材、音效与粒子来自学习期间使用的 Unity 示例资源（SampleAssets 等），版权归原作者。详见仓库根目录的授权说明。
