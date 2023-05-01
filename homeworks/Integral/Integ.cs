using System;
using static System.Console;
using static System.Math;

public static class Integ{
	public static (double,int) integrate(Func<double,double> f, double a, double b,int count=0, double delta=0.001,
		double eps=0.001,double f2=Double.NaN, double f3= Double.NaN){
		double h=b-a;

		if(Double.IsNaN(f2)||Double.IsNaN(f3)){
			f2=f(a+2*h/6);
			f3=f(a+4*h/6);
			WriteLine($"delta {delta},{eps}");
		}
		double f1=f(a+h/6);
		double f4=f(a+5*h/6);
		double Q=(2*f1+f2+f3+2*f4)/6*h;
		double q=(f1+f2+f3+f4)/4*h;
		double err=Abs(Q-q);
		count++;
		if(err<=delta||err<=eps*Abs(Q))
			return (Q,count);
		else {
			(double val1,int count2)=integrate(f,a,(a+b)/2,count,delta/Sqrt(2),eps,f1,f2);
			(double val2,int count1)=integrate(f,(a+b)/2,b,count,delta/Sqrt(2),eps,f3,f4);
			return (val1+val2,count1+count2);
		}
	}
	public static (double,int) integrateCC(Func<double,double> f, double a, double b,double delta=0.001,
		double eps=0.001){
		Func<double,double> f1 = theta => f( (a+b)/2+(b-a)/2*Cos(theta))*Sin(theta)*(b-a)/2;
		return integrate(f1,0,PI,0,delta,eps,Double.NaN,Double.NaN);
	}
}
