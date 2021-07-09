#initialize list to store data
data=[]

#locate and read file
filename="IMDB-Movie-Data.csv"
f=open(filename,"r")
#path=r'C:\Users\user\Desktop\資料科學\HW0\IMDB-Movie-Data.csv'
#f=open(path,"r")
f.readline()
#append data by rows into data
for line in f:
    data.append(line.strip())
#close file
f.close()
#format genre and actor data into nested lists
for movie in range(len(data)):
    data[movie] = data[movie].split(',')
    #split genre and actors ito nested list
    for i in [2,4]:
        data[movie][i] = data[movie][i].split('|')

#file data
genre = 2
director = 3
actor = 4
year = 5
rating = 7 
revenue = 9
#use one major loop to finding data for problems(more efficient)
#initialization of list of movies of 2016 and their ratings
movies_of_2016 = []
#initializationof list of actors and directors
actors = []
directors = []
#initialization of list of average rating for movies with Emma Watson
emma_watson_ratings = []
#initialization of list of actors of each movie
list_cast = []
for i in data:
    #find movies of year 2016 and their ratings
    if i[year] == '2016':
        movies_of_2016.append([i[1],float(i[7])]);
    #find all actors
    for j in range(len(i[actor])):
        i[actor][j] = i[actor][j].strip()
        if i[actor][j] not in actors: 
            actors.append(i[actor][j])
    #find all directors
    if i[director] not in directors:
        directors.append(i[director].strip())
    i[director] = [i[director]]
    #find ratings of movies with Emma Watson
    if 'Emma Watson' in i[4]:
        emma_watson_ratings.append(float(i[7]))
    #format years in data to int for comparison
    i[year] = int(i[year])
    #append actors of each movie
    list_cast.append(i[actor])

#define function to find top x movies of criteria data[1]
def top_X(listc, x):
    #initialize list for comparison and result
    cmp_list = []
    result = []
    #sort index
    for i in range(len(listc)):
        cmp_list.append(listc[i][1])
    cmp_list.sort(reverse=True)
    #find top x
    n = 0
    while n < x:
        for i in range(len(listc)):
            if listc[i][1] == cmp_list[n]:
                if listc[i][0] in result: 
                    continue
                else:
                    result.append(listc[i][0])
        n+=1
    for i in range(len(result)):
        print(result[i],cmp_list[i])
        
#define function used to find number of targets related to subject
def total_Of_Target(data, subject_list, subject, target):
    #initialization of list of targets and total of related targets
    list1 = []
    total = []
    for i in range(len(subject_list)):
        #initialization of related targets
        tmp = []
        #find related targets and append to tmp
        for j in data:
            if subject_list[i] in j[subject]:
                for k in j[target]:
                    if k not in tmp:
                        tmp.append(k)
        list1.append(tmp)
    #determine number of targets and append to total
    for i in range(len(list1)):
        total.append([subject_list[i],len(list1[i])])
    #return list of number of targets related to subjects
    return total
    
#PROBLEMS
print('(1) Top-3 movies with the highest ratings in 2016?')
#use previously defined function to return result
top_X(movies_of_2016, 3)
print('\n')

print('(2) The actor generating the highest average revenue?')
#initialization of list of average revenue
ave_rev = []
#find average revenue
for i in range(len(actors)):
    num = 0
    rev = 0
    for j in data:
        if actors[i] in j[actor] and j[revenue] != '': 
            num += 1
            rev += float(j[revenue])
        elif actors[i] in j[actor]:
            num += 1
    if rev > 0: rev /= num 
    ave_rev.append([actors[i], rev])
#find actor with highest average revenue with previously defined function top_X
top_X(ave_rev, 1)
print('\n')


print('(3) The average rating of Emma Watson’s movies?')
#calculate average rating
ave_rating = sum(emma_watson_ratings) / len(emma_watson_ratings)
print(ave_rating)
print('\n')


print('(4) Top-3 directors who collaborate with the most actors?')
#using previously defined function to find list of actors they collaborate with and number of collaborations
total_num_of_collabs = total_Of_Target(data, directors, director, actor)
#find directors with most amount of collaborations with previously defined top_X function
top_X(total_num_of_collabs, 3)
print('\n')

print('(5) Top-2 actors playing in the most genres of movies?')
#using previously defined function to find list of genres an actor has played in and the number of genres
total_num_of_genres = total_Of_Target(data, actors, actor, genre)
#find actors that played in most number of genres with previously defined top_X function
top_X(total_num_of_genres, 2)
print('\n')

print("(6)Top-3 actors whose movies lead to the largest maximum gap of years? ")
#initialization of list of actors and their maximum gap years
gap = []
#find max gap years and append the result to gap
for i in actors:
    #initialization of earliest and latest year to find gap
    tmp = [2021,0]
    #find earliest and latest year
    for j in data:
        if i in j[actor]:
            if j[year]<tmp[0]: tmp[0] = j[year] 
            if j[year]>tmp[1]: tmp[1] = j[year] 
    #append result
    gap.append([i, tmp[1] - tmp[0]])
#find actors with maximum gap years with previously defined top_X function
top_X(gap, 3)
print('\n')

print("(7)Find all actors who collaborate with Johnny Depp in direct and indirect ways")
#define a recursive function to find collaborations with target actor (set parameter indirect as default true)
def find_Collab(list_collab, target, indirect = True):
    #initialization of list to check for updated collaborations
    updated = []
    #find collaborations within target list and append to updated
    for i in target:
        for j in list_collab:
            if i in j:
                for k in j:
                    if (k not in target) and (k not in updated): updated.append(k) 
    #if default find total direct and indirect collaborations through recursive and stop when no collaborations are updated
    if indirect:
        if len(updated)>0:
            #update target and feed back into function
            target.extend(updated)
            return find_Collab(list_collab, target)
        else:
            #print result and return collaborations with target actor as target index 0
            print(target[0], "total direct and indirect collaborations: ", len(target)-1)
            return target
    #else if indirect is false return direct collaborations with target actor as target index 0
    else: 
        target.extend(updated)
        #print result and return collaborations with target actor as target index 0
        print(target[0], "total direct collaborations: ", len(target)-1)
        return target
#use function find_Collab to find all actors who collaborate with Johnny Depp in direct and indirect ways
j_d_d = find_Collab(list_cast, ["Johnny Depp"], False)
print('List of direct collaborations')
print(j_d_d[1:])
print('\n')
j_d_i = find_Collab(list_cast, ["Johnny Depp"], True)
print('List of direct and indirect collaborations')
print(j_d_i[1:])
print('\n')

