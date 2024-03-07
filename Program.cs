// See https://aka.ms/new-console-template for more information


using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using MathNet.Numerics.Interpolation;
using Sail_Optimizer;



 namespace SailOptimizer
 {
     class Program
     {
         static void Main()
         {
             string filePath = File.ReadAllText(@"C:\Users\patri\Documents\code\Sail Optimizer\polars\Class4_polar_test.txt");

             Polar.LoadPolar(filePath);
             Interpolate(polar, 10, 10);
        }
     }

 }



//double[,] windfield_speed = new double[1000, 1000];
//double[,] windfield_dir = new double[1000, 1000];


//var array_interpolated = MathNet.Numerics.Interpolate.Common(polar, 20 );




Console.WriteLine("Done");