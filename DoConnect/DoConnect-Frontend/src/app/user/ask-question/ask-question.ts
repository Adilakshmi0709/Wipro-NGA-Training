import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { QuestionService } from '../../services/question.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ask-question',
  templateUrl: './ask-question.html',
  styleUrls: ['./ask-question.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class AskQuestionComponent {
  form: FormGroup;
  message = '';
  imageError: string | null = null;

  constructor(private fb: FormBuilder, private questionService: QuestionService, private router: Router) {
    this.form = this.fb.group({
      title: ['', Validators.required],
      text: ['', Validators.required],
      image: [null]
    });
  }

  onFileChange(event: any) {
  if (event.target.files.length > 0) {
    const file: File = event.target.files[0];
    const allowedExtensions = ['jpg', 'jpeg', 'png', 'gif', 'webp'];
    const fileExtension = file.name.split('.').pop()?.toLowerCase();

    if (!fileExtension || !allowedExtensions.includes(fileExtension)) {
      this.imageError = 'Only image files (jpg, jpeg, png, gif, webp) are allowed.';
      event.target.value = ''; // reset input
      this.form.patchValue({ image: null });
      return;
    }

    this.imageError = null; // clear previous error
    this.form.patchValue({ image: file });
    }
  }

  submit() {
    if (this.form.invalid) return;

    const formData = new FormData();
    formData.append('title', this.form.get('title')?.value);
    formData.append('text', this.form.get('text')?.value);
    if (this.form.get('image')?.value) {
      formData.append('image', this.form.get('image')?.value);
    }

    this.questionService.createQuestion(formData).subscribe({
      next: () => {
        this.message = 'Question submitted successfully!';
        this.router.navigate(['/my-questions']);
      },
      error: () => {
        this.message = 'Failed to submit question';
      }
    });
  }
}
