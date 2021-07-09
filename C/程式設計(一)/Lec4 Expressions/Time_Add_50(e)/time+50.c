#include<stdio.h>

int main(){
    int a,b;
    scanf("%d %d",&a,&b);
    b+=50;
    if(b>=60) {
        a+=1;
        b-=60;
    }
    printf("%.2d:%.2d\n",a,b);
    return 0;
}
