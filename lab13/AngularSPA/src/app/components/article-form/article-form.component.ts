import { Component, OnInit, input, output, signal, computed } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Article } from '../../models/article.model';

@Component({
  selector: 'app-article-form',
  imports: [FormsModule],
  templateUrl: './article-form.component.html',
  styleUrl: './article-form.component.css'
})
export class ArticleFormComponent implements OnInit {
  article = input.required<Article>();
  cancel = output<void>();
  save = output<{name: string}>();
  enteredName = signal("");

  ngOnInit() {
      this.enteredName.set(this.article().name);
  }

  onCancel(){
    this.cancel.emit();
  }

  onSubmit(){
    this.save.emit(
      {name: this.enteredName()}
    );
  }

  imagePath = computed(()=> "assets/images/" + this.article().imageName);
}
