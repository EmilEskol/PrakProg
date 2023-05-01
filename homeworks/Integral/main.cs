using System;
using static System.Console;
using static System.Math;
using static Integ;

public class main{
	public static void Main(string[] args){
		Func<double,double> f = x => Sqrt(x);
		double a1 = integrate(f,0,1);
		WriteLine($"{f(1)} {f(9)} {Sqrt(9)}");
		f = x => 1/Sqrt(x);
		double a2 = integrate(f,0,1);
		WriteLine($"integrate Sqrt(x) gives {a1} from 0 to 1");
		WriteLine($"integrate Sqrt(x) gives {a2} from 0 to 1");
		f = x => 4*Sqrt(1-x*x);
		double a3 = integrate(f,0,1);
		WriteLine($"This should be PI: {a3}");
		f = x => 100000*Log(x)/Sqrt(x);
		double a4 = integrate(f,0,1);
		WriteLine($"Log(x)/Sqrt(x) from 0 to 1 gives {a4}");

		double[] xs = new double[128];
		double[] ys = new double[128];
		for(int i=0;i<xs.Length;i++){
			double xVal=i*1.0/16-4;
			xs[i]=xVal;
			ys[i]=erf(xVal);
		}
		IOputs.WriteXY(args,xs,ys,"Erf.data");
	}
	public static double erf(double z){
		if(z<0)
			return -erf(-z);
		else if(z<=1)
			return 2/Sqrt(PI)*integrate(x => Exp(-x*x),0,z);
		else
			return 1-2/Sqrt(PI)*integrate(x => Exp(-Pow((z+(1-x)/x),2))/x/x,0,1);
	}
}
