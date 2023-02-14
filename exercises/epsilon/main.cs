using System;
using static System.Math;
using static System.Console;

static class main{
	static void Main(){
		maxMin();
		machineEpsilon();
		tinyEpsilon();

		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		double d2 = 8*0.1;

		WriteLine($"d1={d1:e15}");
		WriteLine($"d2={d2:e15}");
		WriteLine($"The reason d1==d2 => {d1==d2}");
		WriteLine($"But approx(d1,d2) => {approx(d1,d2)} is that there is a limit to binary precision");
	}
	public static void maxMin(){
		int i=1;
		while(i+1>i) {i++;}
		Write($"my max int = {i}\n");
		Write($"int.MaxValue={int.MaxValue}\n");

		i=1;
		while(i-1<i) {i--;}
		Write($"my min int = {i}\n");
		Write($"int.MinValue={int.MaxValue}\n");
	}
	public static void machineEpsilon(){
		double x=1;
		while(1+x!=1){x/=2;} 
		x*=2;
		Write($"My machine epsilon for double is {x}\n");
		Write($"Machines epsilon should be {Pow(2,-52)}\n");

		float y=1F;
		while((float)(1F+y) != 1F){y/=2F;} 
		y*=2F;
		Write($"My machine epsilon for float is {y}\n");
		Write($"Machines epsilon should be {Pow(2,-23)}\n");
	}
	public static void tinyEpsilon(){
		int n=(int)1e6;
		double epsilon=Pow(2,-52);
		double tiny=epsilon/2;
		double sumA=0,sumB=0;

		sumA+=1; 
		for(int i=0;i<n;i++){sumA+=tiny;}
		
		for(int i=0;i<n;i++){sumB+=tiny;} 
		sumB+=1;

		WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}\n");
		WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}\n");
		WriteLine("The sumB is the right amount because the tiny amount by it self is possible");
		WriteLine("to write in binary and thus requires less space than 1+tiny, which the");
		WriteLine("double havn't space for");
	}
	public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(b-a) < acc) return true;
		else if(Abs(b-a) < Max(Abs(a),Abs(b))*eps) return true;
		else return false;
	}
}
