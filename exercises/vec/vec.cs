using static System.Math;
using static System.Console;

public class vec{
	public double x,y,z;
	//Constructors:
	public vec(){x=y=z=0;}
	public vec(double x,double y,double z){this.x=x; this.y=y;this.z=z;}
	
	//operators:
	public static vec operator*(vec v, double c){return new vec(c*v.x,c*v.y,c*v.z);}
	public static vec operator*(double c, vec v){return v*c;}
	public static vec operator+(vec u, vec v){return new vec(u.x+v.x,u.y+v.y,u.z+v.z);}
	public static vec operator-(vec u){return new vec(-u.x,-u.y,-u.z);}
	public static vec operator-(vec u, vec v){return new vec(u.x-v.x,u.y-v.y,u.z-v.z);}

	//methods:
	public void print(string s){Write(s);WriteLine($"{x} {y} {z}");}
	public void print(){this.print("");}
	public double dot(vec u){return this.x*u.x+this.y*u.y+this.z*u.z;}
	public static double dot(vec v,vec w){return v.x*w.x+v.y*w.y+v.z*w.z;}
	public static double norm(vec v){return Sqrt(dot(v,v));}
	public static vec cross(vec v,vec u){
		return(new vec(v.y*u.z-v.z*u.y,v.z*u.x-v.x*u.z,v.x*u.y-v.y*u.x));}
	
	//approx method:
	static bool approx(double a,double b,double acc=1e-9,double eps=1e-9){
		if(Abs(a-b)<acc) return true;
		if(Abs(a-b)<(Abs(a)+Abs(b))*eps) return true;
		return false;
		}
	public bool approx(vec u){
		if(!approx(this.x,u.x)) return false;
		if(!approx(this.y,u.y)) return false;
		if(!approx(this.z,u.z)) return false;
		return true;
		}
	public static bool approx(vec u,vec v) => u.approx(v);
	
	//ToString:
	public override string ToString(){return $"{x} {y} {z}";}
}
