import os
import zipfile
import re


def zip_files(folder_path, output_zip) -> None:
    with zipfile.ZipFile(output_zip, 'w') as zipf:
        for root, _, files in os.walk(folder_path):
            if root.startswith(f"{folder_path}\Web"):
                continue
            # match folder_path\xyz\bin or folder_path\xyz\obj or folder_path\xyz\.vs
            match: re.Match[str] | None = re.match(
                rf"{folder_path}\\[^\\]+\\(.+)", root)
            if match and any(str(match.group(1)).startswith(beginning) for beginning in ["bin", "obj", ".vs"]):
                continue
            for file in files:
                if not file.endswith('.pdf'):
                    file_path = os.path.join(root, file)
                    zipf.write(file_path, os.path.relpath(
                        file_path, folder_path))


def check(text: str, *checked_texts) -> bool:
    return any([end in text for end in checked_texts])


if __name__ == "__main__":
    folder_path: str = input("Enter the folder path to zip: ")
    folder_name: str = folder_path.split('/')[-1]
    output_zip: str = f"zips/{folder_name.capitalize()}-___-Kubs.zip"
    zip_files(folder_path, output_zip)
    print(f"Files zipped successfully into {output_zip}")
    print("Don't forget to change \"___\" into appropriate text")
