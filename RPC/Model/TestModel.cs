﻿using Newtonsoft.Json;

namespace RPC.Model
{

    public enum TaskType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
    public class TestModel
    {
        public string userName {  get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public TaskType Task { get; set; }
    }


}
