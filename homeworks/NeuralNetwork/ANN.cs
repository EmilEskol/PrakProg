using System;
using static System.Math;
using static System.Console;
using static matrix;

public class ANN{
	static int n,dim;
	static Func<double,double> f = x => x*Exp(-x*x);
	static Func<double,double> inF = x => -0.5*Exp(-x*x);
	static Func<double,double> deF = x => (1-2*x*x)*Exp(-x*x);
	static Func<double,double> de2F = x => (2*x*x-3)*2*x*Exp(-x*x);
	static vector p,x,y;
	double acc=0.000001;
	
	public ANN(int n){
		ANN.n=n;
		p=new vector(3*n);
		//i=a_i,i+1=b_i and i+2=w_i in f((x-a_i)/b_i)*w_i
		p[0]=0.5;p[1]=-0.5;p[2]=2;
		p[3]=-1;p[4]=0.5;p[5]=-2;
		p[6]=0;p[7]=1;p[8]=1;		
	}
	public ANN(vector p){
		ANN.p=p;
		ANN.n=p.size/3;
	}
	public void train(vector x,vector y){
		ANN.x=x.copy();
		ANN.y=y.copy();
		ANN.dim=x.size;
		WriteLine($"the cost function gives {Cost(p)}");
		p.print(" and p is ");
		p=Minimi.qnewton(Cost,p,acc);
		WriteLine($"After trainning the cost function gives {Cost(p)}");
		p.print(" and p is ");
	}
	public static double response(double x){
		double result=0;
		for(int i=0;i<ANN.n;i++){
			int j=i*3;
			result+=f((x-p[j])/p[j+1])*p[j+2];
		}
		return result;
	}
	public static double inResponse(double x){
		double result=0;
		for(int i=0;i<ANN.n;i++){
			int j=i*3;
			result+=inF((x-p[j])/p[j+1])*p[j+2];
		}
		return result;
	}
	public static double deResponse(double x){
		double result=0;
		for(int i=0;i<ANN.n;i++){
			int j=i*3;
			result+=deF((x-p[j])/p[j+1])*p[j+2];
		}
		return result;
	}
	public static double de2Response(double x){
		double result=0;
		for(int i=0;i<ANN.n;i++){
			int j=i*3;
			result+=de2F((x-p[j])/p[j+1])*p[j+2];
		}
		return result;
	}
	public static double Cost(vector p){
		double result=0;
		ANN.p=p;
		for(int k=0;k<dim;k++){
			result+=Pow(response(x[k])-y[k],2);
		}
		return result;
	}
	//Getters
	public vector getP(){
		return p;
	}
	public vector getX(){
		return x;
	}
	public vector getY(){
		return y;
	}
}
