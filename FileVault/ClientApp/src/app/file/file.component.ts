import { Component, OnInit } from '@angular/core';
import { FileService } from "../services/fileService.service";
import { UploadFile } from "../models/uploadFile";
import { Observable } from "rxjs";


@Component({
  selector: 'file',
  templateUrl: './file.component.html',
  providers: [FileService]
})
export class FileComponent implements OnInit {

  uploadedFile: UploadFile = new UploadFile();
  uploadFiles: UploadFile[];
  tableModel: boolean = true;

  constructor(private fileService: FileService) { }

  ngOnInit(): void {
    this.loadFilesList();
  }

  loadFilesList() {
    this.fileService.getFilesList().subscribe((data: UploadFile[]) => this.uploadFiles = data);
  }

  uploadFile(event) {
    let fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      let file: File = fileList[0];
      this.fileService.addFile(file);
    }
  }

  download() {

  }

  deleteFile() {

  }


}
