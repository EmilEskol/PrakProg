using System;
using static System.Math;
public class qSpline{
	vector x,y,b,c;
	int n;
	public qSpline(vector xs,vector ys){
		n=xs.size;
		x=xs.copy();
		y=ys.copy();
		vector c1= new vector(n);
		vector b1= new vector(n);
		for(int i=1;i<n;i++){
			c1[i]=(y[i]-y[i]-c[i-1]*(x[i]-x[i-1]))/(x[i]-x[i-1]);
			b1[i]=y[i]-c[i]*(x[i+1]-x[i]);
		}
		c=c1;
		b=b1;
	}
	public double evaluate(double z){
		int i=Spline.binSearch(x,z);
		return y[i]+b[i]*(z-x[i])+c[i]*Pow(z-x[i],2);
	}
	public double derivative(double z){
		int i=Spline.binSearch(x,z);
		return b[i]+2*c[i]*(z-x[i]);
	}
	public double integral(double z){
		int i=Spline.binSearch(x,z);
		return  y[i]*(z-x[i])+0.5*b[i]*Pow(z-x[i],2)+1/3*c[i]*Pow(z-x[i],3);;
	}
	public vector getb(){
		return b;
	}
	public vector getc(){
		return c;
	}
}
