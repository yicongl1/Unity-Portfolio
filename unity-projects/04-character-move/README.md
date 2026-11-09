# 04. 角色移动

一个最小化的第三人称角色移动 Demo，用来理解「输入 → 朝向 → 位移」的基本流程，并接入角色模型与动画资源。

- Unity 版本：2021.3.18f1c1
- 渲染管线：Built-in
- 输入：旧版 Input Manager

## 场景

| 场景 | 作用 |
|------|------|
| `Assets/Scenes/SampleScene.unity` | 角色移动演示场景 |

## 操作

- `WASD` / 方向键：移动

## 代码结构

| 文件 | 作用 |
|------|------|
| `Assets/Scripts/Char1.cs` | 读取输入、设置朝向、按速度移动 |
| `Assets/SciFiWarrior/` | 角色模型、材质、动画等资源 |
| `Assets/Anime/`、`Assets/Mesh/`、`Assets/Prefabs/` | 动画、网格与预制体资源 |

## 实现要点

- `Input.GetAxis("Horizontal")` / `"Vertical"` 得到输入向量。
- 用「当前位置 + 移动方向」得到目标点，再调用 `transform.LookAt(target)` 让角色转向。
- 用 `speed * Time.deltaTime` 保证不同帧率下移动速度一致。
- 当前移动方向直接使用世界坐标轴，没有做「相对摄像机方向」的转换，适合作为入门示例；要进一步扩展可以改为相机相对移动。

## 备注

- 没有输入时角色保持当前朝向，不会调用 `LookAt(transform.position)`。
- `SampleScene` 已加入 Build Settings，可以直接构建。

## 第三方内容

`SciFiWarrior` 角色模型与动画资源包来自第三方，版权归原作者。详见仓库根目录的授权说明。
