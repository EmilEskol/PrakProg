using System;
using static System.Console;
using static System.Math;
using static matrix;
using static Minimi;

public class main{
	static Func<double,double> f;
	static vector x,y,y1;
	static int nr;
	static ANN ANN1;
		
	public static void Main(string[] args){
		PartA(args);
		PartB(args);
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


		ANN1 = new ANN(3);
		
		nr=1000;
		y=new vector(nr);
		y1=new vector(nr);
		x=new vector(nr);
		(x,y)=trainData(10.0,1000);
		IOputs.WriteXY(args,x,y,"valPartA.data");
		
		ANN1.train(x,y);
		//(x,y)=trainData(4.0,1000);
		//ANN1.train(x,y);
		(x,y)=trainData(2.0,1000);
		ANN1.train(x,y);
		
		nr=300;
		y1=new vector(nr);
		y=new vector(nr);
		x=new vector(nr);
		for(int i=0;i<nr;i++){
			x[i]=2.2/nr*i-1.1;
			y[i]=f(x[i]);
			y1[i]=ANN.response(x[i]);
		}
		IOputs.WriteXY(args,x,y1,"ANNresPartA.data");
		
		
	}
	public static void PartB(string[] args){
		WriteLine("=========Part b=============");
		WriteLine("Finding derivative, second derivative and integral of Cos(5*x-1)*Exp(-x*x)");
		WriteLine("For the integral the function -1/2*Exp(-x*x) is used in ANN");
		WriteLine("For the first derivative the function (1-2x)*Exp(-x*x) is used in ANN");
		WriteLine("For the second derivate the function (2x^2-3)*2x*Exp(-x*x) is used in ANN");
		WriteLine("Which is compared for the first derivative with Exp(-x*x)*(-5*Sin(5*x-1)-2*x*Cos(5*x-1))");
		WriteLine("and for the second derivative Exp(-x*x)*(20*x*Sin(5*x-1)-(4*x*x-27)*Cos(5*x-1))");
		WriteLine("and for the integral "); 
		Func<double,double> inF = x =>Exp(-x*x)*(-5*Sin(5*x-1)-2*x*Cos(5*x-1));
		Func<double,double> deF = x =>Exp(-x*x)*(-5*Sin(5*x-1)-2*x*Cos(5*x-1));
		Func<double,double> de2F = x =>Exp(-x*x)*(20*x*Sin(5*x-1)-(4*x*x-27)*Cos(5*x-1));
		nr=300;
		vector yIn=new vector(nr);
		vector yDe=new vector(nr);
		vector yDe2=new vector(nr);
		vector yInVal=new vector(nr);
		vector yDeVal=new vector(nr);
		vector yDe2Val=new vector(nr);
		x=new vector(nr);
		for(int i=0;i<nr;i++){
			x[i]=2.2/nr*i-1.1;
			yIn[i]=ANN.inResponse(x[i]);
			yDe[i]=ANN.deResponse(x[i]);
			yDe2[i]=ANN.de2Response(x[i]);
			yInVal[i]=inF(x[i]);
			yDeVal[i]=deF(x[i]);
			yDe2Val[i]=de2F(x[i]);
		}
		IOputs.WriteXY(args,x,yIn,"ANNresInPartB.data");
		IOputs.WriteXY(args,x,yInVal,"ValInPartB.data");
		IOputs.WriteXY(args,x,yDe,"ANNresDePartB.data");
		IOputs.WriteXY(args,x,yDeVal,"ValDePartB.data");
		IOputs.WriteXY(args,x,yDe2,"ANNresDe2PartB.data");
		IOputs.WriteXY(args,x,yDe2Val,"ValDe2PartB.data");
			
	}
	public static (vector x,vector y) trainData(double interval,int nrf){
		y=new vector(nrf);
		x=new vector(nrf);
		for(int i=0;i<nrf;i++){
			x[i]=interval/nrf*i-interval/2;
			y[i]=f(x[i]);
		}
		return (x,y);
	}
}
