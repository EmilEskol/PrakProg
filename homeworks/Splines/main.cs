using System;
using static System.Console;
using static System.Math;
using static Spline;
using static vector;


class main{
	static int Main(string[] args){
		int returnValue=0;
		double[] xs,ys;
		(xs,ys)=IOputs.ReadXY(args);
		for(int i=0;i<xs.Length;i++)
			WriteLine($"{xs[i]} {ys[i]}");
		IOputs.WriteXY(args,xs,ys,"Data.data");
		WriteLine("z chosen to be 5.5");
		double z=5.5;
		double yz=linterp(xs,ys,z);
		WriteLine($"y(z)={yz}");
		double yzInteg=linterpInteg(xs,ys,z);
		WriteLine($"and the area under the graf from 0 to z is {yzInteg}");
		double[] xzs=new double[2],yzs=new double[2];
		xzs[0]=z;
		yzs[0]=yz;
		WriteLine("New z at 14,7");
		z=14.7;
		yz=linterp(xs,ys,z);
		WriteLine($"y(z)={yz}");
		yzInteg=linterpInteg(xs,ys,z);
		WriteLine($"and the area under the graf from 0 to z is {yzInteg}");
		xzs[1]=z;
		yzs[1]=yz;
		IOputs.WriteXY(args,xzs,yzs,"LineterpIntegTests.data");
		double[] xzs1=new double[8]{0.1,10.6,12.6,15.2,15.3,15.7,16.234,16.738};
		double[] yzs1= new double[xzs1.Length];
		for(int i=0;i<xzs1.Length;i++)
			yzs1[i]=linterp(xs,ys,xzs1[i]);
		IOputs.WriteXY(args,xzs1,yzs1,"LineterpTests.data");
		vector x= new vector("1 2 3 4 5");
		vector y1= new vector(5);
		vector y2 = new vector(5);
		vector y3 = new vector(5);
		for(int i=0;i<x.size;i++){
			y1[i]=1;
			y2[i]=x[i];
			y3[i]=Pow(x[i],2);
		}
		qSpline q1= new qSpline(x,y1);
		qSpline q2= new qSpline(x,y2);
		qSpline q3= new qSpline(x,y3);
		WriteLine("The values are: ");
		vector b1=q1.getb();
		b1.print("b1:");
		vector b2=q2.getb();
		b2.print("b2:");
		vector b3=q3.getb();
		b3.print("b3:");
		
		vector c1=q1.getc();
		c1.print("c1:");
		vector c2=q2.getc();
		c2.print("c2:");
		vector c3=q3.getc();
		c3.print("c3:");
		WriteLine("and should be");
		return returnValue;
	}
}
