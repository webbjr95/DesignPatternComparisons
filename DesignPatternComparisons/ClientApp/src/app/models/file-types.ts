import { KeyValue } from "@angular/common";

export class FileTypes {
  constructor() {}

  EXCEL:KeyValue<string, string> = { key: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', value: 'xlsx' }
  PDF: KeyValue<string, string> = { key: 'application/pdf', value: 'pdf' }

  GetFileExtensionFromMime(type: string): string {
    var extension = ''

    switch (type) {
      case this.EXCEL.key:
        extension = this.EXCEL.value
        break;
      case this.PDF.key:
        extension = this.PDF.value
        break;
    }

    return extension
  }
}
