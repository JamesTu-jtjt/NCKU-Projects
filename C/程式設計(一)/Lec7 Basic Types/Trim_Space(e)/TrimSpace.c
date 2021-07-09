#include<stdio.h>

int main(){
    int a;
    char ch;
    a=0;
    while((ch=getchar())!='\n'){
        if (ch==' '){
            a++;
            if(a==2){
                a--;
            }
            else if (a==1)printf("%c",ch);
        }
        else {
            printf("%c", ch);
            a=0;
        }
    }
    return 0;
}