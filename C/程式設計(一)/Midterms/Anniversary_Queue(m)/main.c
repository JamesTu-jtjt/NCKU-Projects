#include<stdio.h>

int main(){
    int x,y,n,i,j;
    scanf("%d %d",&x,&y);
    int a[x],b[y];
    for(n=0;n<x;n++)scanf("%d",&a[n]);
    for(n=0;n<y;n++)scanf("%d",&b[n]);
    i=0;
    j=0;
    while(i<x || j<y){
        if(a[i]<b[j]){
            printf("%d ",a[i]);
            i++;
        }
        else if(a[i]>b[j]){
            printf("%d ",b[j]);
            j++;
        }
        if(i==x){
            for(n=j;n<y;n++)printf("%d ",b[n]);
            break;
        }
        else if(j==y){
            for(n=i;n<x;n++)printf("%d ",a[n]);
            break;
        }
    }
    return 0;
}
