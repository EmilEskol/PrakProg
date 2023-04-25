using System;
using static System.Console;
using static System.Math;
using static Spline;
using static vector;


class main{
	static int Main(string[] args){
		int returnValue=0;
		//Linear spline
		double[] xs,ys;
		(xs,ys)=IOputs.ReadXY(args);
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

		//Qaudratic spline
		vector x= new vector(10);
		vector y1= new vector(10);
		vector y2 = new vector(10);
		vector y3 = new vector(10);
		vector y4 = new vector(10);
		for(int i=0;i<x.size;i++){
			x[i]=i;
			y1[i]=1;
			y2[i]=x[i];
			y3[i]=0.1*Pow(x[i],2);
			y4[i]=Cos(x[i]);
		}
		WriteLine("Data for qaudratic spline:");
		x.print("x:");
		y4.print("y:");
		qSpline q4= new qSpline(x,y4);
		
		WriteLine("The vectors for the splines are: ");
		vector b4=q4.getb();
		b4.print("b4:");
		vector c4=q4.getc();
		c4.print("c4:");
		
		//Making a plot with q4
		(double[] xs1,double[] ys1)=q4.printData(100);
		IOputs.WriteXY(args,xs1,ys1,"qSpline4.data");
		(xs1,ys1)=q4.printDerivative(100);
		IOputs.WriteXY(args,xs1,ys1,"qSpline4D.data");
		(xs1,ys1)=q4.printIntegral(100);
		IOputs.WriteXY(args,xs1,ys1,"qSpline4I.data");
		
		double[] xqData= new double[x.size];
		double[] yqData= new double[x.size];
		for(int i=0;i<x.size;i++){
			xqData[i]=x[i];
			yqData[i]=y4[i];
		}
		IOputs.WriteXY(args,xqData,yqData,"qData.data");
		
		return returnValue;
	}
}
