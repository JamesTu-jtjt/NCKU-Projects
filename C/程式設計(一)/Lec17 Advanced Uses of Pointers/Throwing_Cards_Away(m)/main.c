#include<stdio.h>
#include<stdlib.h>

struct card {
    int value;
    struct card *next;
};

struct deck {
    int num;
    struct card *first;
    struct card *next;
    struct card *last;
};

void add_card(struct deck *deck, int value){
    struct card *new;
    new = malloc(sizeof(struct card));
    new->value=value;
    new->next=deck->first;
    deck->next=deck->first;
    deck->first=new;
    if(deck->last==NULL) deck->last=deck->first;
}

void throw(struct deck *deck){
    printf("%d ", deck->first->value);
    struct card *p;
    p=deck->first;
    deck->last->next=deck->next;
    deck->last=deck->next;
    deck->first=deck->next->next;
    deck->next=deck->first->next;
    deck->first->next=deck->next;
    free(p);
}

int main(){
    int n,m;
    scanf("%d %d", &n, &m);
    struct deck deck;
    deck.num=n;
    deck.first=NULL;
    deck.next=NULL;
    deck.last=NULL;
    for(int i=n;i>0;i--){
        add_card(&deck, i);
    }
    while(m>0){
        throw(&deck);
        m--;
    }
    return 0;
}

