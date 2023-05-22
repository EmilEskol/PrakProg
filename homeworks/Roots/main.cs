using System;
using static System.Console;
using static System.Math;
using static matrix;
using static Roots;

public class main{
	static double rmin,rmax,acc,eps;
	static int count=0;
	static vector yrmin,yrmax;
	static genlist<double> xList;
	static genlist<vector> yList;
	static string[] args;
	static Func<double,vector,vector> f1;
	
	public static void Main(string[] args1){
		args=args1;
		WriteLine("===========Part a============");
		var rnd = new Random();
		vector guess,root;
		Func<vector,vector> f = x => new vector(x[0]*x[0]-1,x[1]*x[1]-4);
		for(int i=0;i<2;i++){
			guess=new vector(rnd.NextDouble()*10-5,rnd.NextDouble()*10-5);
			root=NMBL(f,guess);
			WriteLine("Finding root in f(x)=x^2-2 from ");
			guess.print("Guess: ");
			root.print("A root is at ");
			f(root).print("And has value ");
		}
		WriteLine("Finding extremum of the Rosenbrocks valley function ");
		WriteLine("The derivative is f'(x)=-2*(1-x)-400*x*(y-x^2),200*(y-x^2)");
		for(int i=0;i<5;i++){
			f= x => new vector(-2*(1-x[0])-400*x[0]*(x[1]-x[0]*x[0]),200*(x[1]-x[0]*x[0]));
			guess=new vector(rnd.NextDouble()*0.5+1,rnd.NextDouble()+2);
			if(i==1)
				guess=new vector(-1.34,1.81);
			guess.print($"Guess {i}: ");
			root=NMBL(f,guess,Pow(10,-3));
			root.print("A root is at ");
			f(root).print("And the derivative has the value ");
			WriteLine($"the functions value at this point is {Pow((1-root[0]),2)+100*Pow(root[1]-Pow(root[0],2),2)}"); 
		}
		WriteLine("============Part b===============");
		vector E= new vector(1);
		rmin=Pow(2,-6);
		rmax=9;
		E[0]=-1;
		acc=0.01;
		eps=0.01;
		double[] xSol=new double[100],ySol=new double[100];

		for(int i=0;i<100;i++){
			xSol[i]=9.0/100*i;
			ySol[i]=xSol[i]*Exp(-xSol[i]);
		}
		IOputs.WriteXY(args,xSol,ySol,"Solution.data");
		
		xList=null;
		yList=null;
		yrmin=new vector(rmin-rmin*rmin,1-2*rmin);
		root=NMBL(func,E,Pow(10,-3));
		root.print("A possible energi is ");
		WriteLine($"This took {count} tries with rmin = {rmin},rmax = {rmax}");
		
		xList= new genlist<double>();
		yList= new genlist<vector>();
		f1= (x,y) => new vector(y[1],-2*(root[0]*y[0]+1/x*y[0]));
		yrmax=ODE.driver(f1,rmin,rmax,yrmin,xList,yList);
		IOputs.WriteXY(args,xList,yList,"Estimate.data");

		//Checking for the different convergence
		int nrRuns=7;
		double[] ConRmin=new double[nrRuns],ConRmax=new double[nrRuns],ConAcc=new double[nrRuns],
			ConEps=new double[nrRuns],ValRmin=new double[nrRuns],ValRmax=new double[nrRuns],
			ValAcc=new double[nrRuns],ValEps=new double[nrRuns];
		xList=null;
		yList=null;
		for(int i=1;i<nrRuns+1;i++){
			count=0;
			
			rmin=Pow(2,-(i+4));
			WriteLine($"rmin={rmin}");
			yrmin=new vector(rmin-rmin*rmin,1-2*rmin);
			root=NMBL(func,E,Pow(10,-3));
			ConRmin[i-1]=Abs(-0.5-root[0]);
			ValRmin[i-1]=rmin;
			rmin=Pow(2,-6);
			yrmin=new vector(rmin-rmin*rmin,1-2*rmin);

			rmax=i+8;
			root=NMBL(func,E,Pow(10,-2));
			ConRmax[i-1]=Abs(-0.5-root[0]);
			ValRmax[i-1]=rmax;
			rmax=9;

			eps=0;
			acc=Pow(10,-(i+1));
			root=NMBL(func,E,Pow(10,-2));
			ConAcc[i-1]=Abs(-0.5-root[0]);
			ValAcc[i-1]=acc;

			acc=0;
			eps=Pow(4,-i);
			root=NMBL(func,E,Pow(10,-2));
			ConEps[i-1]=Abs(-0.5-root[0]);
			ValEps[i-1]=eps;
			acc=0.01;
			eps=0.01;
		}
		IOputs.WriteXY(args,ValRmin,ConRmin,"ConRmin.data");
		IOputs.WriteXY(args,ValRmax,ConRmax,"ConRmax.data");
		IOputs.WriteXY(args,ValAcc,ConAcc,"ConAcc.data");
		IOputs.WriteXY(args,ValEps,ConEps,"ConEps.data");
	}
	public static vector func(vector E){
		count++;
		f1= (x,y) => new vector(y[1],-2*(E[0]+1/x)*y[0]);
		yrmax=ODE.driver(f1,rmin,rmax,yrmin,xList,yList,0.001,acc,eps);
		if(count > 10000){
			WriteLine($"acc={acc},eps={eps}");
			yrmax.print("Best quess ");
			WriteLine($"With the energy {E[0]}");
			//throw new Exception("Bad energy guess");
			WriteLine(">10^4 counts====");
			return new vector(0,0);
		}
		return yrmax;
	}
		
}
