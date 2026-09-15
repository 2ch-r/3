using System; using ImGuiNET; using SharpPluginLoader.Core; using SharpPluginLoader.Core.Entities;
namespace MHWAnimationController;
public sealed class AnimationControllerPlugin:IPlugin{
 public string Name=>"MHW 动作控制器 v3 Minimal"; public string Author=>"OpenAI";
 int set,id; bool paused; string status="就绪";
 public PluginData Initialize()=>new(){ImGuiWrappedInTreeNode=true};
 public void OnImGuiRender(){
  var p=Player.MainPlayer; if(p is null||p.Instance==0){ImGui.Text("未取得猎人对象");return;}
  try{
   var a=p.ActionController.CurrentAction;
   ImGui.Text($"当前动作组: {a.ActionSet}"); ImGui.Text($"当前动作ID: {a.ActionId}"); ImGui.Separator();
   ImGui.InputInt("目标动作组",ref set); ImGui.InputInt("目标动作ID",ref id);
   if(ImGui.Button("读取当前动作")){set=a.ActionSet;id=a.ActionId;status=$"已读取 {set}:{id}";}
   ImGui.SameLine();
   if(ImGui.Button("执行目标动作"))try{p.ActionController.DoAction(set,id);status=$"已请求执行 {set}:{id}";}catch(Exception e){status="执行失败: "+e.Message;}
   ImGui.Separator();
   if(!paused){if(ImGui.Button("暂停动画")){p.PauseAnimations();paused=true;status="动画已暂停";}}
   else if(ImGui.Button("恢复动画")){p.ResumeAnimations();paused=false;status="动画已恢复";}
   ImGui.TextWrapped("状态: "+status);
   ImGui.TextWrapped("本版不直接替换 AnimationId，只通过 ActionController 执行动作。");
  }catch(Exception e){ImGui.TextWrapped("错误: "+e.Message);}
 }
}