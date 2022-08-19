
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { MatDialogRef, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'delete-dialog',
  templateUrl: './delete-dialog.component.html',
})
export class DeleteDialogComponent {
  constructor(public dialogRef: MatDialogRef<DeleteDialogComponent>) { }

  closeDialog() {
    this.dialogRef.close();
  }
}



