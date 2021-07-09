#include <stdio.h>

int main(){
    int a,b1,b2,b3,b4,b5,b6,c1,c2,c3,c4,c5,x,y,sum;
    scanf("%1d %1d%1d%1d%1d%1d%1d %1d%1d%1d%1d%1d", &a,&b1,&b2,&b3,&b4,&b5,&b6,&c1,&c2,&c3,&c4,&c5);
    x=a+b2+b4+b6+c2+c4;
    y=3*(b1+b3+b5+c1+c3+c5);
    sum=x+y;
    printf("%d",9-(sum-1)%10);
    return 0;
}