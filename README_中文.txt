覆盖到你原来的 GitHub 仓库并 Commit，Actions 自动编译。
下载 Artifacts 里的 AnimationController-v3-Minimal，解压 DLL 后放到：
Monster Hunter World\nativePC\plugins\CSharp\
先删除旧 AnimationController.dll。

本版只保留：读取当前 Action Set/ID、执行 Action Set/ID、暂停/恢复。
已经彻底删除 v2 会闪退的直接 AnimationId 替换逻辑。
建议先观察游戏正常动作对应的 Set/ID，再拿已确认的数值测试，不要随机输入未知动作。
