using System;
using static System.Console;
using static System.Math;
using static vector;


class main{
	static int Main(string[] args){
		int returnValue=0;
		bool time=false;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-time")
				if(words[1]=="true")
					time=true;
		}
		if(!time){
			partA(args);
			partB1(args);
			partB2(args);
		}
		else
			partC(args);
		
		return returnValue;
	}
	public static void partA(string[] args){
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
		
		BerrutSpline berrut= new BerrutSpline(args,x,y1);
		BerrutSpline berrut2= new BerrutSpline(args,x,y2);

		//Making a plot with berut
		WriteLine("Making a plot with berut");
		(double[] xs,double[] ys)=berrut.printData(100);
		(double[] xs2,double[] ys2)=berrut2.printData(100);

		IOputs.WriteXY(args,xs,ys,"berrutSpline.data");
		IOputs.WriteXY(args,xs2,ys2,"berrutSpline2.data");
		
		IOputs.WriteXY(args,x,y1,"berrutData.data");
		IOputs.WriteXY(args,x,y2,"berrutData2.data");
	}
	public static void partB1(string[] args){
		//Testing different methods to make berut spline converge
		WriteLine("Testing different methods to make berut spline converge");
		vector x1= new vector(10);
		vector x2= new vector(10);
		vector x3= new vector(30);
		vector x4= new vector(30);
		vector y1= new vector(10);
		vector y2= new vector(10);
		vector y3= new vector(30);
		vector y4= new vector(30);
		
		for(int j=0;j<x3.size;j++){
			if(j<x1.size){
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
		
		BerrutSpline berrut3= new BerrutSpline(args,x1,y1);
		(double[] xs3,double[] ys3)=berrut3.printData(100);
		IOputs.WriteXY(args,xs3,ys3,"berrutSplineCos.data");

		berrut3= new BerrutSpline(args,x2,y2);
		(xs3, ys3)=berrut3.printData(100);
		IOputs.WriteXY(args,xs3,ys3,"berrutSplineCos2.data");

		berrut3= new BerrutSpline(args,x3,y3);
		(xs3,ys3)=berrut3.printData(100);
		IOputs.WriteXY(args,xs3,ys3,"berrutSplineCos3.data");

		berrut3= new BerrutSpline(args,x4,y4);
		(xs3,ys3)=berrut3.printData(100);
		IOputs.WriteXY(args,xs3,ys3,"berrutSplineCos4.data");
	}
	public static void partB2(string[] args){
		/*	Testing convergence of different functions with using a broader band 
			and larger amounts of numbers*/
		WriteLine("Testing convergence of different functions with using a broader band\nand larger amounts of numbers");	
		Func<double,double> f= x=>Cos(x);
		Conver(args,f,"Convergence.data",10,50);
		f= x=> Exp(-x*x);
		Conver(args,f,"Convergence2.data",10,50);
		f= x=> x*x;
		Conver(args,f,"Convergence3.data",10,50);
		f= x=> 2*x*x;
		Conver(args,f,"Convergence4.data",10,50);
	
		
	}
	public static void partC(string[] args){
		int nThreads=1;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-threads")
				nThreads=(int)float.Parse(words[1]);
		}
		WriteLine($"N# of threads: {nThreads}");
		int nPoints=200000000;
		int nEvals=10000;
		double[] x= new double[nPoints];
		double[] y= new double[nPoints];
		for(int i=0;i<nPoints;i++){
			x[i]=i*1.0/nPoints-0.5;
			y[i]=Exp(-x[i]*x[i]);
		}
		BerrutSpline berrut= new BerrutSpline(args,x,y);
		for(int i=0;i>nEvals;i++)
			berrut.evaluate(i*0.8/nEvals-0.4);		
	}
	public static void Conver(string[] args, Func<double,double> f,string filename,int step,int max){
		double diff=0;
		int nPoints=100;
		genlist<double> diffs= new genlist<double>();
		genlist<double> nData= new genlist<double>();
		vector x,y;
		for(int i=step;i<=max;i+=step){
			x= new vector(i);
			y= new vector(i);
			for(int j=0;j<x.size;j++){
				x[j]=j;
				y[j]=f(x[j]);
			}
			//WriteLine($"step {i}");
			BerrutSpline berrut= new BerrutSpline(args,x,y);
			(double[] xs,double[] ys)=berrut.printData(nPoints);
			/*for(int j=0;j<500;j++){
				WriteLine($"{xs[j]}	{ys[j]}");
			}*/
			diff=0;
			for(int j=0;j<nPoints;j++){
				diff+=Pow(ys[j]-f(xs[j]),2)/nPoints;
			}
			nData.add(i);
			diffs.add(diff);
		}
		IOputs.WriteXY(args,nData,diffs,filename);
	}
}
