<template>
  <div>
    <!-- Modal Dialog -->
    <div class="modal fade" id="questionDialog" tabindex="-1" aria-labelledby="questionDialogLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="questionDialogLabel">
              {{ question ? "Edit Question" : "Create Question" }}
            </h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <!-- Form -->
            <form>
              <!-- Question Text -->
              <div class="mb-3">
                <label for="questionText" class="form-label">Question Text</label>
                <textarea
                  id="questionText"
                  class="form-control"
                  rows="3"
                  v-model="localQuestion.questionText"
                  required
                ></textarea>
              </div>

              <!-- Sort Order -->
              <div class="mb-3">
                <label for="sortOrder" class="form-label">Sort Order</label>
                <input
                  type="number"
                  id="sortOrder"
                  class="form-control"
                  v-model.number="localQuestion.sortOrder"
                  required
                />
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
            <button type="button" class="btn btn-primary" @click="saveQuestion">Save</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import * as bootstrap from "bootstrap";
import { defineComponent, PropType, ref, watch } from "vue";
import { QuestionnaireAPI } from "../api/QuestionnaireApi";
import { Question } from "../models/models";

export default defineComponent({
  name: "QuestionCreateEdit",
  props: {
    questionnaireId: {
      type: Number,
      required: true,
    },
    question: {
      type: Object as PropType<Question>,
      required: false,
    },
  },
  setup(props) {
    const localQuestion = ref<Question>({
      id: 0,
      questionnaireId: props.questionnaireId,
      questionText: "",
      sortOrder: 0,
    });

    // Watch for the provided question and populate form if available
    watch(
      () => props.question,
      (newQuestion) => {
        if (newQuestion) {
          localQuestion.value = { ...newQuestion };
        }
      },
      { immediate: true }
    );

    // Save question
    const saveQuestion = async () => {
      try {
        console.log(props);
        localQuestion.value.questionnaireId = props.questionnaireId;

        await QuestionnaireAPI.CreateOrUpdateQuestion(localQuestion.value);
        closeDialog();
      } catch (error) {
        console.error("Error saving question:", error);
      }
    };

    // Close dialog
    const closeDialog = () => {
      const modalElement = document.getElementById("questionDialog");
      if (modalElement) {
        const modal = bootstrap.Modal.getInstance(modalElement);
        modal?.hide();
      }
    };

    return {
      localQuestion,
      saveQuestion,
      closeDialog,
    };
  },
});
</script>

<style scoped>
/* Optional: Add any specific styles if needed */
</style>
