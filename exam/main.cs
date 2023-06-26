using System;
using static System.Console;
using static System.Math;
using static vector;


class main{
	static int Main(string[] args){
		int returnValue=0;

		//Berut spline
		vector x= new vector(10);
		vector y1= new vector(10);
		vector y2 = new vector(10);
		for(int i=0;i<x.size;i++){
			x[i]=i;
			y1[i]=x[i];
			y2[i]=0.1*Pow(x[i],2);
		}
		
		
		WriteLine("Data for Berrutspline:");
		x.print("x:");
		y2.print("y:");
		
		BerrutSpline berrut= new BerrutSpline(x,y1);
		BerrutSpline berrut2= new BerrutSpline(x,y2);
		
		//Making a plot with berut
		(double[] xs,double[] ys)=berrut.printData(100);
		(double[] xs2,double[] ys2)=berrut2.printData(100);

		IOputs.WriteXY(args,xs,ys,"berrutSpline.data");
		IOputs.WriteXY(args,xs2,ys2,"berrutSpline2.data");
		
		IOputs.WriteXY(args,x,y1,"berrutData.data");
		IOputs.WriteXY(args,x,y2,"berrutData2.data");

		//Testing different methods to make berut spline converge
		vector x1= new vector(10);
		vector x2= new vector(10);
		vector x3= new vector(30);
		vector x4= new vector(30);
		vector y3= new vector(30);
		vector y4= new vector(30);
		
		for(int j=0;j<x3.size;j++){
			WriteLine($"j{j} {x3.size}");
			if(j<x1.size){
				WriteLine("j>x2.size");
				x1[j]=j;
				x2[j]=3*j;
				y1[j]=Cos(x1[j]);
				y2[j]=Cos(x2[j]);
			}
			x3[j]=j*1.0/3;
			x4[j]=j;
			y3[j]=Cos(x3[j]);
			y4[j]=Cos(x4[j]);
		}
		IOputs.WriteXY(args,x4,y4,"berrutDataCos.data");
		
		BerrutSpline berrut3= new BerrutSpline(x1,y1);
		(double[] xs3,double[] ys3)=berrut3.printData(100);
		IOputs.WriteXY(args,xs3,ys3,"berrutSplineCos.data");

		berrut3= new BerrutSpline(x2,y2);
		(xs3, ys3)=berrut3.printData(100);
		IOputs.WriteXY(args,xs3,ys3,"berrutSplineCos2.data");

		berrut3= new BerrutSpline(x3,y3);
		(xs3,ys3)=berrut3.printData(100);
		IOputs.WriteXY(args,xs3,ys3,"berrutSplineCos3.data");

		berrut3= new BerrutSpline(x4,y4);
		(xs3,ys3)=berrut3.printData(100);
		IOputs.WriteXY(args,xs3,ys3,"berrutSplineCos4.data");
		
		
		/*	Testing convergence of different functions with using a broader band 
			and larger amounts of numbers*/	
		Conver(args,100,1000);

		
		return returnValue;
	}
	public static void Conver(string[] args,int step,int max){
		double diff=0;
		genlist<double> diffs= new genlist<double>();
		genlist<double> nData= new genlist<double>();
		vector x,y;
		for(int i=step;i<=max;i+=step){
			x= new vector(i);
			y= new vector(i);
			for(int j=0;j<x.size;j++){
				x[j]=j;
				y[j]=Cos(x[j]);
			}

			BerrutSpline berrut= new BerrutSpline(x,y);
			(double[] xs,double[] ys)=berrut.printData(500);
			
			diff=0;
			for(int j=0;j<500;j++){
				diff+=Pow(ys[j]-Cos(xs[j]),2);
			}
			nData.add(i);
			diffs.add(diff);
		}
		IOputs.WriteXY(args,nData,diffs,"Convergence.data");
	}
}
