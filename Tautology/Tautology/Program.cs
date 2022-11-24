using System;
using System.Collections.Generic;
namespace Namespace1
{
    static class Program
    {
        static void Main(string[] args)
        {
            TestTautology();
        }
        private static void TestTautology()
        {
            string n = Console.ReadLine();
            int num = int.Parse(n);
            for (int i = 0; i < num; i++)
            {
                if (EvaluateExpression.IsTautology(Console.ReadLine()))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
    public class EvaluateExpression
    {
        private string expression;
        private Tree expressionTree;
        char[] substituions = new char[26];
        int substituteCount = 0;
        private char[] operators = new char[] { 'I', 'C', 'D', 'N', 'E' };
        private EvaluateExpression(string expression)
        {
            this.expression = expression;
        }
        public static bool IsTautology(string expression)
        {
            EvaluateExpression ex = new EvaluateExpression(expression);
            int endIndex = 0;
            ex.GenerateAlternateExpression();
            ex.expressionTree = ex.ParseExpression(0, out endIndex);
            return ex.VerifyAllCombinations();
        }
        private bool VerifyAllCombinations()
        {
            long limit = 1 << substituteCount;
            for (int i = 0; i < limit; i++)
            {
                if (Evaluate(i, expressionTree))
                    continue;
                return false;
            }
            return true;
        }
        private bool Evaluate(int i, Tree t)
        {
            if (t.type == SymbolType.Variable)
            {
                return (i & (1 << (t.node - 'a'))) != 0;
            }
            else
            {
                if (t.node == 'N')
                    return !Evaluate(i, t.left);
                if (t.node == 'C')
                    if (Evaluate(i, t.left))
                        return Evaluate(i, t.right);
                    else
                        return false;
                if (t.node == 'D')
                    if (!Evaluate(i, t.left))
                        return Evaluate(i, t.right);
                    else
                        return true;
                if (t.node == 'I')
                {
                    bool left = Evaluate(i, t.left);
                    if (left)
                    {
                        return Evaluate(i, t.right);
                    }
                    return true;
                }
                if (t.node == 'E')
                {
                    return Evaluate(i, t.left) == Evaluate(i, t.right);
                }
                return true;
            }
        }
        private Tree ParseExpression(int startIndex, out int endIndex)
        {
            Tree t = new Tree();
            t.node = expression[startIndex];
            endIndex = startIndex;
            t.type = SymbolType.Variable;
            SymbolType type = GetSymbolType(expression[startIndex]);
            if (type == SymbolType.Operator)
            {
                t.type = SymbolType.Operator;
                if (expression[startIndex] == 'N')
                {
                    t.left = ParseExpression(startIndex + 1, out endIndex);
                }
                else
                {
                    t.left = ParseExpression(startIndex + 1, out endIndex);
                    t.right = ParseExpression(endIndex + 1, out endIndex);
                }
            }
            return t;
        }
        private SymbolType GetSymbolType(char ch)
        {
            foreach (char ch1 in this.operators)
            {
                if (ch1 == ch)
                    return SymbolType.Operator;
            }
            return SymbolType.Variable;
        }
        private void GenerateAlternateExpression()
        {
            char[] alternateExpressions = new char[expression.Length];
            for (int i = 0; i < expression.Length; i++)
            {
                if (GetSymbolType(expression[i]) == SymbolType.Operator)
                {
                    alternateExpressions[i] = expression[i];
                    continue;
                }
                if (substituions[expression[i] - 'a'] != 0)
                    alternateExpressions[i] = substituions[expression[i] - 'a'];
                else
                {
                    substituions[expression[i] - 'a'] = (char)(substituteCount + 'a');
                    alternateExpressions[i] = (char)(substituteCount + 'a');
                    substituteCount++;
                }
            }
            this.expression = new string(alternateExpressions);
        }
        public enum SymbolType
        {
            Operator,
            Variable
        }
        public class Tree
        {
            public char node;
            public SymbolType type;
            public Tree left, right;
        }
    }
}