using FlowEngine.Abstractions.ExecutionEngine;
using FlowEngine.Avalonia.GraphModel;
using FlowEngine.Avalonia.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtHost.Nodes
{
    public class ConditionFlowNode : FlowNodeBase
    {
        DataConnector<bool> _cond;
        FlowConnector _trueBranch;
        FlowConnector _falseBranch;

        public ConditionFlowNode()
        {
            Title = "条件";
            this.CreateFlowInput();
            _cond = this.CreateInput(false, "条件");
            _trueBranch = this.CreateFlowOutput("True");
            _falseBranch = this.CreateFlowOutput("False");

        }
        public override NodeExecResult OnExecute(INodeExecutionContext context)
        {
            var cond = context.GetPortValue(_cond);
            if (cond)
            {
                context.ExecNextNode(_trueBranch);
            }
            else
            {
                context.ExecNextNode(_falseBranch);
            }
            return SuccessResult;
        }
    }
}
