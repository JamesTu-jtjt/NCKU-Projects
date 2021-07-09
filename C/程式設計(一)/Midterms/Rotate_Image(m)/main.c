#include<stdio.h>

int main(){
    int r,x,y,i,j;
    scanf("%d %d %d",&r,&x,&y);
    int a[x][y],b[y][x];
    if(r==90){
        for(i=(x-1);i>=0;i--){
            for(j=0;j<=(y-1);j++){
                scanf("%d",&b[j][i]);
            }
        }
        for(i=0;i<y;i++){
            for(j=0;j<x;j++) {
                printf("%d ", b[i][j]);
                if(j==x-1)printf("\n");
            }
        }
    }
    else if(r==180){
        for(i=(x-1);i>=0;i--){
            for(j=(y-1);j>=0;j--){
                scanf("%d",&a[i][j]);
            }
        }
        for(i=0;i<x;i++){
            for(j=0;j<y;j++) {
                printf("%d ",a[i][j]);
                if(j==y-1)printf("\n");
            }
        }
    }
    else if(r==270){
        for(i=0;i<=(x-1);i++){
            for(j=(y-1);j>=0;j--){
                scanf("%d",&b[j][i]);
            }
        }
        for(i=0;i<y;i++){
            for(j=0;j<x;j++) {
                printf("%d ", b[i][j]);
                if(j==x-1)printf("\n");
            }
        }
    }
    return 0;
}
