using System;
using static System.Console;
using static System.Math;

public static class Integ{
	public static double integrate(Func<double,double> f, double a, double b, double delta=0.001,
		double eps=0.001,double f2=Double.NaN, double f3= Double.NaN){
		double h=b-a;
		if(Double.IsNaN(f2)||Double.IsNaN(f3)){
			f2=f(a+2*h/6);
			f3=f(a+4*h/6);
		}
		double f1=f(a+h/6);
		double f4=f(a+5*h/6);
		double Q=(2*f1+f2+f3+2*f4)/6*h;
		double q=(f1+f2+f3+f4)/4*h;
		double err=Abs(Q-q);
		if(err<=delta||err<=eps*Abs(Q))
			return Q;
		else return integrate(f,a,(a+b)/2,delta/Sqrt(2),eps,f1,f2)+
					integrate(f,(a+b)/2,b,delta/Sqrt(2),eps,f3,f4);
	}
	public static double intregrateCC(Func<double,double> f, double a, double b,double delta=0.001,
		double eps=0.001){
		return 1;
	}
}
