#include<stdio.h>

int main(){
    int ch,len,r1,r2,g1,g2,b1,b2;
    len=0;
    while(len<=7){
        len++;
        ch=getchar();
        switch(ch){
            case 65: ch=10;
                break;
            case 66: ch=11;
                break;
            case 67: ch=12;
                break;
            case 68: ch=13;
                break;
            case 69: ch=14;
                break;
            case 70: ch=15;
                break;
            case 48: ch=0;
                break;
            case 49: ch=1;
                break;
            case 50: ch=2;
                break;
            case 51: ch=3;
                break;
            case 52: ch=4;
                break;
            case 53: ch=5;
                break;
            case 54: ch=6;
                break;
            case 55: ch=7;
                break;
            case 56: ch=8;
                break;
            case 57: ch=9;
                break;
        }
        switch(len){
            case 2: r1=16*ch;
                break;
            case 4: g1=16*ch;
                break;
            case 6: b1=16*ch;
                break;
            case 3: r2=ch;
                break;
            case 5: g2=ch;
                break;
            case 7: b2=ch;
                break;
        }
    }
    printf("rgb(%d,%d,%d)",r1+r2,g1+g2,b1+b2);
    return 0;
}
