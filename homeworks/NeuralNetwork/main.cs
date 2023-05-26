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
		WriteLine("Training ANN on x^2");
		f = x => Cos(5*x-1)*Exp(-x*x);
		int nr=5000;
		var rnd =new Random();
		x= new vector(nr);
		y= new vector(nr);
		
		for(int i=0;i<nr;i++){
			//x[i]=rnd.NextDouble()*2-1;
			x[i]=2.0/nr*i-1;
			y[i]=f(x[i]);
		}
		var ANN1 = new ANN(3);
		ANN1.getP().print("P = ");
		nr=200;
		y1=new vector(nr);
		x=new vector(nr);
		for(int i=0;i<nr;i++){
			x[i]=2.0/nr*i-1;
			y1[i]=ANN1.response(x[i]);
		}
		IOputs.WriteXY(args,x,y1,"ANNresPartA1.data");

		
		WriteLine($"Early response: x=0 {ANN1.response(0)}");
		Write($"and x=1 {ANN1.response(1)}");
		Write($"and x=-1 {ANN1.response(-1)} \n");

		ANN1.train(x,y);

		ANN1.getP().print("found P ");
		nr=200;
		y1=new vector(nr);
		y=new vector(nr);
		x=new vector(nr);
		for(int i=0;i<nr;i++){
			x[i]=2.0/nr*i-1;
			y[i]=f(x[i]);
			y1[i]=ANN1.response(x[i]);
		}
		IOputs.WriteXY(args,x,y,"valPartA.data");
		IOputs.WriteXY(args,x,y1,"ANNresPartA.data");
		
	}
	public static void PartB(string[] args){
		WriteLine("=========Part b=============");
		WriteLine("Finding derivatives, second derivatives and antiderivative");	
	}
	
}
