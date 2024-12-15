import os
import zipfile


def zip_files(folder_path, output_zip):
    with zipfile.ZipFile(output_zip, 'w') as zipf:
        for root, dirs, files in os.walk(folder_path):
            x = input()
            if x:
                continue
            for file in files:
                if not file.endswith('.pdf'):
                    file_path = os.path.join(root, file)
                    zipf.write(file_path, os.path.relpath(
                        file_path, folder_path))


if __name__ == "__main__":
    folder_path: str = input("Enter the folder path to zip: ")
    folder_name: str = folder_path.split('/')[-1]
    output_zip: str = f"zips/{folder_name.capitalize()}-___-Kubs.zip"
    zip_files(folder_path, output_zip)
    print(f"Files zipped successfully into {output_zip}")
    print("Don't forget to change \"___\" into appropriate text")
