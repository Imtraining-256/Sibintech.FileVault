import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable()
export class FileService {

  private url = "/api/files/";

  private defaultUserName = "Domain@Fedya";

  constructor(private http: HttpClient) {
  }

  getFilesList() {
    return this.http.get(this.url + 'GetFilesList' + '/' + this.defaultUserName);
  }

  getDownload(id: number, fileName: string) {

    let params = new HttpParams().set('id', id.toString());

    this.http.get(this.url + 'Download', { params: params, responseType: 'blob' })
      .subscribe((res) => {
        var a = document.createElement("a");
        a.href = URL.createObjectURL(res);
        a.download = fileName;
        a.click();
      });
  }

  public addFile = (file) => {

    let fileToUpload = <File>file;
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    formData.append('userName', this.defaultUserName);
    return this.http.post(this.url + 'AddFile', formData, { observe: 'events' });
  }

  deleteFile(id: number) {
    return this.http.delete(this.url + 'Delete/' + id);
  }
}
