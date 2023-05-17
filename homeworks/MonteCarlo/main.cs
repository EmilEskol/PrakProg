using System;
using static System.Console;
using static System.Math;
using static matrix;
using static monteCarlo;

public class main{
	public static void Main(string[] args){
		WriteLine("Setup for unit sphere");
		vector a = new vector(2);
		vector b = new vector(1,2*PI);
		Func<vector,double> f = x => x[0];
		double[] xs = new double[10];
		double[] ys = new double[10];
		double[] ys1 = new double[10];
		double[] ys2 = new double[10];
		
		(double val,double err)=plMonteCarlo(f,a,b,100000);
		a.print("a=");
		b.print("b=");
		WriteLine($"f(r)=1 and the result is {val} +- {err}");
		WriteLine($"and it should be {PI}");
		for(int i=0;i<10;i++){
			xs[i]=Pow(5,i+1);
			(val,err)=plMonteCarlo(f,a,b,(int) xs[i]);
			ys[i]=err;
			ys1[i]=Abs(PI-val);
			ys2[i]=1/Sqrt(xs[i]);
		}
		IOputs.WriteXY(args,xs,ys,"EstErr.data");
		IOputs.WriteXY(args,xs,ys1,"ReelErr.data");
		IOputs.WriteXY(args,xs,ys2,"val.data");
		WriteLine("Calculating (1-cos(x)*cos(y)*cos(z))^-1");
		f = x => Pow(PI*PI*PI*(1-Cos(x[0])*Cos(x[1])*Cos(x[2])),-1);
		a = new vector(3);
		b = new vector(PI,PI,PI);
		(val, err)=plMonteCarlo(f,a,b,1000000);
		a.print("a=");
		b.print("b=");
		WriteLine($"f(x)=x^2+y^2 and the result is {val} +- {err}");
		WriteLine($"and it should be {1.39320393}");


		WriteLine("===============Part b===================");
		f = x => x[0];
		a = new vector(2);
		b = new vector(1,2*PI);
		(val,err)=qMonteCarlo(f,a,b,100000);
		a.print("a=");
		b.print("b=");
		WriteLine($"f(x)=r^2 and the result is {val} +- {err}");
		WriteLine($"and it should be {PI}");

		for(int i=0;i<10;i++){
			xs[i]=Pow(5,i+1);
			(val,err)=qMonteCarlo(f,a,b,(int) xs[i]);
			ys[i]=err;
			(val,err)=plMonteCarlo(f,a,b,(int) xs[i]);
			ys1[i]=err;
		}
		IOputs.WriteXY(args,xs,ys1,"plainErr.data");
		IOputs.WriteXY(args,xs,ys,"quasiErr.data");
		
	}
}
