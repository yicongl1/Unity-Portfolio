# Unity 学习作品集

2021–2022 年学习 Unity 游戏开发与 C# 编程期间完成的项目合集，包含 4 个 Unity 原型和 8 个 C# 控制台练习。三个游戏的 Windows 版本放在 `release-assets/`，同时发布在 GitHub Releases。

这些项目大多始于教程和课堂练习，后来逐步加入了关卡、UI、状态机、粒子、音效等自己的改动。把它们收在一起，主要是为了记录学习过程，也方便以后回顾 Unity 的常用 API 和 C# 基础。

---

## 项目一览

| # | 项目 | 类型 | 主要内容 |
|---|------|------|----------|
| 01 | [滚动球街机合集](unity-projects/01-rolling-ball-arcade/README.md) | 3D / 多场景 | 用主菜单串联 3 个小游戏：滚球闯关、迷宫、拉箱子解谜，另含第一人称控制器演示 |
| 02 | [飞龙射击](unity-projects/02-dragon-shooter/README.md) | 2D / 竖版射击 | 玩家移动与连发、随机刷怪、敌人受击反馈、Boss 巡逻状态机、屏幕比例适配 |
| 03 | [变色跑酷](unity-projects/03-color-runner/README.md) | 3D / 无限跑酷 | 自动前进、跳跃、红绿换色、颜色不匹配死亡、粒子与 Game Over UI |
| 04 | [角色移动](unity-projects/04-character-move/README.md) | 3D / 角色控制 | 第三人称世界坐标移动、LookAt 朝向、角色动画资源接入 |
| — | [C# 基础练习](csharp-exercises/README.md) | 控制台程序 | 面向对象、集合、单例、加权随机、回合制战斗等 8 个练习 |

---

## Unity 项目

### 01. 滚动球街机合集

一个 Unity 工程里放了多个小游戏，通过 `UIfront` → `UI` 两个场景进入菜单选择。

- **Rolling Ball**：3D 滚球闯关。WASD 控制左右与前后，空格跳跃；速度会随前进/后退变化，背景音乐的音调同步变化；碰到障碍物或掉出平台判负，到达终点判胜。
- **Maze**：迷宫滚球。用 `Rigidbody.AddForce` 给球施加力，而不是直接改位置；支持暂停面板和重新开始。
- **PullTheBox**：第三人称拉箱子解谜。鼠标指向控制角色朝向，左键伸出手臂抓取箱子，右键放下；把对应颜色的箱子送到同色灯下即可通关。
- **Mini First Person Controller**：接入的第三方第一人称示例控制器，用于学习移动、视角、跳跃、下蹲、缩放和脚步音效。

这个项目主要练习了 `Rigidbody` 速度与力的区别、`OnTriggerEnter` / `OnCollisionEnter`、`SceneManager` 场景切换、`Time.timeScale` 暂停、协程、UGUI 面板、相机跟随、`LookAt`、音频与材质控制。

### 02. 飞龙射击

竖版 2D 射击小游戏，两个场景：`UI`（开始界面）和 `Game`（战斗）。

- 玩家用方向键/WASD 在边界内移动，按住 `J` 连续发射子弹，射击间隔由冷却时间控制。
- 敌人在屏幕上方随机位置、随机间隔生成，向下移动；受击时闪红，血量归零后播放爆炸特效。
- Boss（Guard）先向下移动到指定高度，再在左右边界之间往返巡逻。
- 背景通过滚动材质 UV 制造移动感，摄像机根据屏幕宽高比动态调整正交尺寸，适配不同分辨率。

这个项目主要练习了协程刷怪、`Instantiate` 与 `Destroy`、2D 触发器、`Mathf.Clamp`、材质 UV 动画、正交摄像机适配和简单状态机。

### 03. 变色跑酷

3D 无限跑酷。角色自动向前跑，玩家只需要跳跃和换色。

- `Space` 跳跃，`J` 在红色 / 绿色之间切换。
- 角色颜色必须与脚下平台颜色一致，否则死亡；死亡时根据当前颜色播放不同粒子。
- 相机用 `Vector3.Lerp` 平滑跟随，失败后弹出 Game Over 面板，可重新开始或退出。

这个项目主要练习了 `Rigidbody.velocity`、碰撞标签判断、`Animator` 参数、粒子预制体、单例式 `GameMode` 和 UI 回调。

### 04. 角色移动

一个最小化的第三人称角色移动 Demo，用来理解「输入 → 朝向 → 位移」的基本流程。

- `Input.GetAxis` 获取水平/垂直输入，组合成世界坐标方向向量。
- 用 `transform.LookAt` 让角色朝向移动方向，再按 `speed * Time.deltaTime` 位移。
- 接入 SciFiWarrior 角色模型与动画资源，配合场景搭建做展示。

---

## C# 基础练习

这些是学习 C# 语法和面向对象时写的控制台程序，后来逐步过渡到游戏逻辑。

| # | 目录 | 练习内容 |
|---|------|----------|
| 01 | `01-boxing-singleton` | 单例管理器、对象数组、拳击对战、复活与残血狂暴 |
| 02 | `02-singleton-and-arrays` | 单例工具类、一维/二维数组的随机填充与打印 |
| 03 | `03-object-copy` | 对象复制、构造函数、命名参数 |
| 04 | `04-list-operations` | `List` 的遍历、筛选、删除与原地修改 |
| 05 | `05-gacha-draw` | 按权重抽卡、累计概率、随机数 |
| 06 | `06-turn-based-battle` | 回合制战斗、技能与状态、伤害公式、持续治疗 |
| 07 | `07-dictionary` | `Dictionary` 的增删改查、遍历时安全删除 |
| 08 | `08-water-bottle` | 类与对象、状态约束、简单交互菜单 |

详细说明见 [csharp-exercises/README.md](csharp-exercises/README.md)。

---

## 涉及的技术点

**C#**

- 面向对象：类、对象、封装、属性、构造函数、继承、接口
- 常用集合：数组、`List<T>`、`Dictionary<TKey, TValue>`
- 设计模式：单例、简单状态机、对象管理器
- 其他：枚举、命名参数、`Random` 加权随机、`TryParse`

**Unity**

- 生命周期：`Awake` / `Start` / `Update` / `FixedUpdate` / `LateUpdate`
- 物理：`Rigidbody` 速度与力、碰撞体、`OnTriggerEnter` / `OnCollisionEnter`
- 场景：`SceneManager.LoadScene`、`Time.timeScale` 暂停
- 表现：UGUI、TextMeshPro、`Animator`、`ParticleSystem`、`AudioSource`、材质 UV 动画
- 工具：协程、预制体、相机跟随、`Mathf.Clamp` / `Lerp` / `LookAt`

---

## 如何运行

### 下载可执行版本

三个游戏已经打包为 Windows 64 位版本，放在 `release-assets/`：

| 游戏 | 文件 | 大小 |
|------|------|------|
| 滚动球街机合集 | [rolling-ball-arcade.zip](release-assets/rolling-ball-arcade.zip) | 61.8 MB |
| 飞龙射击 | [dragon-shooter.zip](release-assets/dragon-shooter.zip) | 26.2 MB |
| 变色跑酷 | [color-runner.zip](release-assets/color-runner.zip) | 25.6 MB |

这些压缩包也发布在 [GitHub Releases](https://github.com/yicongl1/Unity-Portfolio/releases/latest)，可以从那里下载。

下载后解压，双击对应的 `.exe`。如果 Windows 弹出 SmartScreen 提示，选择「更多信息 → 仍要运行」。

这些 exe 来自学习阶段的旧构建，不包含后来对源码的小修复。想体验最新行为，可以用 Unity 打开对应工程运行。

### 用 Unity 打开源码

| 项目 | Unity 版本 |
|------|------------|
| 01 滚动球街机合集 | 2021.3.5f1c1 |
| 02 飞龙射击 | 2021.3.5f1c1 |
| 03 变色跑酷 | 2021.3.5f1c1 |
| 04 角色移动 | 2021.3.18f1c1 |

推荐用 Unity Hub 安装对应的 2021.3 LTS 版本（或更新的 2021.3.x）。打开工程后：

1. 等待 Unity 重新导入资源（首次打开会重建 `Library/`，需要一些时间）。
2. 在 `Project` 窗口打开对应场景。
3. 点击 Play。

各项目的入口场景与操作方式写在各项目的 README 中。

### 编译 C# 练习

`csharp-exercises` 下每个目录都是一个独立的 .NET Framework 4.7.2 控制台项目。用 Visual Studio 打开 `csharp-exercises/CSharpExercises.sln`，可以一次加载全部 8 个项目；也可以单独打开某个 `.csproj`。

---

## 目录结构

```text
Unity-Portfolio/
├─ unity-projects/              # Unity 源码工程（仅 Assets / Packages / ProjectSettings）
│  ├─ 01-rolling-ball-arcade/
│  ├─ 02-dragon-shooter/
│  ├─ 03-color-runner/
│  └─ 04-character-move/
├─ csharp-exercises/            # C# 控制台练习
│  ├─ CSharpExercises.sln
│  ├─ 01-boxing-singleton/
│  ├─ 02-singleton-and-arrays/
│  ├─ 03-object-copy/
│  ├─ 04-list-operations/
│  ├─ 05-gacha-draw/
│  ├─ 06-turn-based-battle/
│  ├─ 07-dictionary/
│  └─ 08-water-bottle/
├─ docs/
│  └─ portfolio-intro.md
├─ release-assets/              # Windows 构建包
│  ├─ README.md
│  ├─ rolling-ball-arcade.zip
│  ├─ dragon-shooter.zip
│  └─ color-runner.zip
├─ .editorconfig
├─ .gitattributes
├─ .gitignore
└─ README.md
```

`release-assets/` 保存 Windows 构建包，GitHub Releases 提供同样的下载；解压后的 `builds/` 目录不提交。

---

## 文档

- [个人网站简介](docs/portfolio-intro.md)

---

## 说明

- Unity 工程保留 `Assets`、`Packages`、`ProjectSettings`；`Library`、`Temp`、`obj`、`Logs`、`UserSettings` 等生成目录不提交。
- 可执行版本保存在 `release-assets/`，同时发布在 GitHub Releases。
- 项目基于旧版 Input Manager（`Input.GetAxis`），没有使用新 Input System。
- 部分脚本保留了学习阶段的注释、调试代码和未使用字段，逻辑以可运行和可读为主。
- `05-gacha-draw` 每次抽卡都会新建 `Random`，属于学习期的简单写法；`06-turn-based-battle` 的暴击字段目前只是预留。

---

## 第三方资源与授权

代码为本人学习期间编写。工程中使用了一些第三方素材，包括但不限于：

- Mini First Person Controller（Unity Asset Store 示例控制器）
- SciFiWarrior 角色模型与动画资源包
- SampleAssets / SimpleFX 等特效、音效与示例资源
- 天空盒、贴图、音频等素材

这些素材的版权归原作者所有，**不在本仓库的代码授权范围内**。仓库仅用于个人学习记录和作品展示；使用或再分发这些素材时，请遵守原作者的许可协议。

---

## 后续计划

- 压缩 `01-rolling-ball-arcade/Assets/Texture` 中体积较大的天空盒贴图，减小仓库体积。
- 视需要为大文件启用 Git LFS。
- 更新 `release-assets/` 中的构建包，并同步到 GitHub Releases。
