import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { UploadFile } from "../models/uploadFile";

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

  addFile(userName: string, content: Int8Array, fileName: string) {
    let params = new HttpParams();

    params = params.append('userName', userName);
    params = params.append('content', String(content));
    params = params.append('fileName', fileName);

    return this.http.post(this.url, {params});
  }

  deleteFile(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
