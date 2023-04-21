using System;
using static System.Console;
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
		for(int i=1;i<n-2;i++){
			c1[i]=((y[i+1]-y[i])/(x[i+1]-x[i])-(y[i]-y[i-1])/(x[i]-x[i-1])-c1[i-1]*(x[i]-x[i-1]))/(x[i+1]-x[i]);
		}
		for(int i=0;i<n-1;i++){
			b1[i]=(y[i+1]-y[i])/(x[i+1]-x[i])-c1[i]*(x[i+1]-x[i]);
		}
		vector c2= new vector(n);
		vector b2= new vector(n);
		for(int i=n-3;i>=0;i--){
			c2[i]=((y[i+2]-y[i+1])/(x[i+2]-x[i+1])-(y[i+1]-y[i])/(x[i+1]-x[i])-c2[i+1]*(x[i+2]-x[i+1]))/(x[i+1]-x[i]);
		}
		for(int i=0;i<n-1;i++){
			b2[i]=(y[i+1]-y[i])/(x[i+1]-x[i])-c2[i]*(x[i+1]-x[i]);
		}
		c2.print("c2");
		c1.print("c1");
		c=c1/2+c2/2;
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
	public (double[],double[]) printData(double z,int m){
			int size=n*m;
			double step;
			double[] xData = new double[size];
			double[] yData = new double[size];
			for(int i=0;i<n-1;i++){
				for(int j=0;j<m;j++){
					step=j*(x[i+1]-x[i])/n;
					xData[m*i+j]=x[i]+step;
					yData[m*i+j]=y[i]+b[i]*step+c[i]*step*step;
				}
			}
		return (xData,yData);
	}
}
