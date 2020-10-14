import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { UploadFile } from "../models/uploadFile";
import { Observable } from "rxjs";

@Injectable()
export class FileService {

  private url = "/api/files/";

  private defaultUserName = "TestUser1";

  constructor(private http: HttpClient) {
  }

  getFilesList() {
    return this.http.get(this.url + 'GetFilesList' + '/' + this.defaultUserName);
  }

  getDownload(id: number, fileName: string) {
    let params = new HttpParams();

    params = params.append('id', String(id));
    params = params.append('id', fileName);

    return this.http.get(this.url, {params});
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
    return this.http.delete(this.url + '/' + id);
  }
}
