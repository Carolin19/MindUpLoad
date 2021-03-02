import random
import os

# some arbitrary function
def swap_case(data):
    s = ' '.join(data)
    res = s.swapcase()
    return res

# save string to .txt files
def save_to_disk(data):
    # give random filenames
    for i in range(10):
        fn = 'f_' + str(random.randint(1,100000)) + '.txt'
        with open('data/'+fn, 'w') as f:
            f.write(data)
    print('save_to_disk finished')

# rename files
def rename_files(path):
    files = os.listdir(path)
    index = 0
    for file in files:
        # if it is a new file, rename it
        if not file.startswith('googleimg_'):
            os.rename(os.path.join(path, file), os.path.join(path, "googleimg_"+''.join([str(index+1), '.txt'])))
            # increase index by 1
            index += 1

    print('rename_files finished')


# Main function
# Like if __name__ == '__main__':
#    wd = webdriver.Chrome(executable_path=DRIVER_PATH)
#   ...

# We call this function from masterfunction.py and
# this function calls the functions above
def get_google_images(Form_name):
    # call first function (like fetch_image_urls)
    s = swap_case(Form_name)
    # call second function
    save_to_disk(s)
    # call 3rd function
    path = 'data'
    rename_files(path)
