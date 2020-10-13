import { Component, OnInit } from '@angular/core';
import { FileService } from './services/fileService.service';
import { UploadFile } from "./models/uploadFile"

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [FileService]
})
export class AppComponent implements OnInit {

  uploadFile: UploadFile = new UploadFile();
  uploadFiles: UploadFile[];
  tableModel: boolean = true;

  constructor(private fileService: FileService) {  }

  ngOnInit(): void {
     this.loadFilesList();
  }

  loadFilesList() {
     this.fileService.getFilesList().subscribe((data: UploadFile[]) => this.uploadFiles = data);
  }

  upload() {

  }

  download() {

  }

  deleteFile() {

  }


}
