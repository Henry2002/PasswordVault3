
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { MatDialogRef, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'overwrite-primary-dialog',
  templateUrl: './overwrite-primary-dialog.html',
})
export class OverwritePrimaryDialogComponent {
  constructor(public dialogRef: MatDialogRef<OverwritePrimaryDialogComponent>) { }

  closeDialog() {
    this.dialogRef.close();
  }
}



