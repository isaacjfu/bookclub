import json
import plyvel # requires pip install plyvel
import sys

AUTHOR_DB_FILE = 'testdb'
AUTHOR_RAW_FILE = 'OL_Dump_Authors_2024-04-30.txt'

BOOK_RAW_FILE = 'OL_Dump_2024-04-30.txt'
BASE_BOOK_JSON_FILE = 'book_data/books_data_'

def handle_author_data():
    db = plyvel.DB(AUTHOR_DB_FILE, create_if_missing = True)
    # author_dict = {}
    with open(AUTHOR_RAW_FILE, 'r') as input_file:
        count = 0
        for line in input_file:
            #print(line)
            x = line.split('\t')
            y = json.loads(x[4])
            name = y['name'] if 'name' in y else '-'
            db.put(str.encode(x[1]),str.encode(name))
            #author_dict[x[1]] = name
            count+=1
            print(count)
    # with open(AUTHOR_JSON_FILE, 'w') as outfile:
    #     json.dump(author_dict,outfile, indent = 2)
    del db

#started 5:55pm
def handle_book_data():
    book_list = []
    with open(BOOK_RAW_FILE, 'r') as input_file, plyvel.DB(AUTHOR_DB_FILE) as db:
        count = 0
        file_count = 1
        for line in input_file:
            x = line.split('\t')
            y = json.loads(x[4])
            title = y['title'] if 'title' in y else 'unknown'
            try:
                author = db.get(str.encode(y['authors'][0]['author']['key'])).decode('utf-8')
            except:
                author = 'unknown'
            book = {
                'title' : title,
                'author' : author
            }
            book_list.append(book)
            print(count)
            count += 1
            if count == 10000000:
                count = 0
                current_json_file = BASE_BOOK_JSON_FILE + str(file_count) + '.json'
                with open(current_json_file, 'w') as output_file:
                    json.dump(book_list, output_file, indent = 2)
                book_list.clear()
                file_count += 1
    return

def testing():
    with plyvel.DB(AUTHOR_DB_FILE) as db, open(AUTHOR_RAW_FILE, 'r') as input_file:
        for line in input_file:
            x = line.split('\t')
            y = json.loads(x[4])
            print(db.get(str.encode(x[1])))
if sys.argv[1] == '1':
    handle_author_data()
elif sys.argv[1] == '2':
    handle_book_data()
elif sys.argv[1] == '3':
    testing()

