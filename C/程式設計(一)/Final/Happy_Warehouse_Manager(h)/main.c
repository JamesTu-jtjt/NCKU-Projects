#include <stdio.h>
#include <stdlib.h>
#include <string.h>

const char *good_types[] = {
        "Juice",
        "Wine",
        "Laptop"
};

void *produce(void *top_of_stack, const char *good_type, size_t count);
void *consume(void *top_of_stack, size_t count);
void list_remain(void *top_of_stack);

int main(){
    char record[64], *job, *good;
    size_t count;
    void *top_of_stack = NULL;

    while(fgets(record, 64, stdin)){
        job = strtok(record, " ");
        if(!strcmp(job, "Produce")){
            good = strtok(NULL, " ");
            count = atol(strtok(NULL, " "));

            for(int i = 0; i < 3; i++){
                if(!strcmp(good, good_types[i])){
                    top_of_stack = produce(top_of_stack, good_types[i], count);
                    break;
                }
            }
        }
        else if(!strcmp(job, "Consume")){
            count = atol(strtok(NULL, " "));
            top_of_stack = consume(top_of_stack, count);
        }
    }

    list_remain(top_of_stack);

    return 0;
}

struct prod{
    char product[10];
    int count;
    struct prod* next;
};

void *produce(void *top_of_stack, const char *good_type, const size_t count){
    struct prod *new=top_of_stack;
    struct prod *add=malloc(sizeof(struct prod));
    if(!top_of_stack){
        strcpy(add->product, good_type);
        add->count=count;
        add->next=NULL;
        new=add;
    }
    else {
        if(!strcmp(new->product,good_type)) new->count+=count;
        else{
            strcpy(add->product, good_type);
            add->count=count;
            add->next=new;
            new=add;
        }
    }
    return new;
}

void *consume(void *top_of_stack, const size_t count){
    struct prod *e=top_of_stack;
    int a=count;
    while(a>e->count){
        a-=e->count;
        struct prod *f;
        f=e;
        e=e->next;
        free(f);
    }
    if(a==e->count){
        struct prod *f;
        f=e;
        e=e->next;
        free(f);
    }
    else if(a<e->count) e->count=e->count-a;
    return e;
}

void list_remain(void *top_of_stack){
    struct prod *p=top_of_stack;
    struct prod *cur;
    if(!p) printf("Empty\n");
    else{
        for(cur=p;cur!=NULL;cur=cur->next){
            printf("%s x %d\n",cur->product,cur->count);
        }
    }
}