import { Component, OnInit } from '@angular/core';
import { FileService } from "../services/fileService.service";
import { UploadFile } from "../models/uploadFile";
import { HttpEventType } from '@angular/common/http';


@Component({
  selector: 'file',
  templateUrl: './file.component.html',
  providers: [FileService]
})
export class FileComponent implements OnInit {

  uploadedFile: UploadFile = new UploadFile();
  uploadFiles: UploadFile[];

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
      this.fileService.addFile(file).subscribe(event => {
        if (event.type == HttpEventType.Response)
          this.loadFilesList();
      });
    }
  }

  download(f: UploadFile) {
    this.fileService.getDownload(f.id, f.fileName);
  }

  deleteFile(f: UploadFile) {
    this.fileService.deleteFile(f.id).subscribe((data => this.loadFilesList()));
  }


}
