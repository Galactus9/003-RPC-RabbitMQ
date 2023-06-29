using RPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpcServer
{
    internal static class Calculator
    {
        internal static double? Calculate(TestModel model)
        {
            if (model.Task == TaskType.Addition)
            {
                return model.Number1 + model.Number2;
            }
            else if (model.Task == TaskType.Subtraction)
            {
                return model.Number1 - model.Number2;
            }
            else if (model.Task == TaskType.Multiplication)
            {
                return model.Number1 * model.Number2;
            }
            else if (model.Task == TaskType.Division)
            {
                return model.Number1 / model.Number2;
            }
            else
            {
                return null;
            }
        }
    }
}
