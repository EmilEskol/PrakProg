using System;
using static System.Console;
using static System.Math;
using static matrix;
using static Minimi;

public class main{
	static Func<double,double> f;
	static vector x,y,y1;
		
	public static void Main(string[] args){
		PartA(args);
		//PartB(args);
	}

	public static void PartA(string[] args){
		WriteLine("=========Part a============");
		WriteLine("Training ANN on ");
		f = x => Cos(5*x-1)*Exp(-x*x);
		int nr=100;
		//var rnd =new Random();
		x= new vector(nr);
		y= new vector(nr);
		
		for(int i=0;i<nr;i++){
			//x[i]=rnd.NextDouble()*2-1;
			x[i]=4.0/nr*i-2;
			y[i]=f(x[i]);
		}
		vector p=new vector("0.462 -0.383 1.82 -0.69 0.381 -1.4 -0.0528 1.21 0.315");


		var ANN1 = new ANN(3);
		
		nr=1000;
		y=new vector(nr);
		y1=new vector(nr);
		x=new vector(nr);
		(x,y)=trainData(10.0,1000);
		IOputs.WriteXY(args,x,y,"valPartA.data");
		
		ANN1.train(x,y);
		(x,y)=trainData(4.0,1000);
		ANN1.train(x,y);
		(x,y)=trainData(2.0,1000);
		ANN1.train(x,y);
		
		nr=200;
		y1=new vector(nr);
		y=new vector(nr);
		x=new vector(nr);
		for(int i=0;i<nr;i++){
			x[i]=8.0/nr*i-4;
			y[i]=f(x[i]);
			y1[i]=ANN.response(x[i]);
		}
		IOputs.WriteXY(args,x,y1,"ANNresPartA.data");
		
		
	}
	public static void PartB(string[] args){
		WriteLine("=========Part b=============");
		WriteLine("Finding derivatives, second derivatives and antiderivative");	
	}
	public static (vector x,vector y) trainData(double interval,int nr){
		y=new vector(nr);
		x=new vector(nr);
		for(int i=0;i<nr;i++){
			x[i]=interval/nr*i-interval/2;
			y[i]=f(x[i]);
		}
		return (x,y);
	}
}
