import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class FileService {

  private url = "/api/files/";

  private defaultUserName = "Fedya";

  constructor(private http: HttpClient) {
  }

  getFilesList() {
    return this.http.get(this.url + 'GetFilesList' + '/' + this.defaultUserName);
  }

  getDownload(id: number, fileName: string) {

    let headers = new HttpHeaders().set('id', id.toString());
    headers.set('fileName', fileName);

    this.http.get(this.url + 'Download', { headers: headers, responseType: 'blob' })
      .subscribe((res) => {
        var a = document.createElement("a");
        a.href = URL.createObjectURL(res);
        a.download = fileName;
        // start download
        a.click();
      });
  }

  public addFile = (file) => {

    let fileToUpload = <File>file;
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    formData.append('userName', 'Fedya');
    this.http.post(this.url + 'AddFile', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        console.log(event);
      });
  }

  deleteFile(id: number) {
    return this.http.delete(this.url + 'Delete/' + id);
  }
}
