<template>
  <div
    class="modal fade"
    id="questionnaireModal"
    tabindex="-1"
    aria-labelledby="questionnaireModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content">
        <!-- Modal Header -->
        <div class="modal-header">
          <h5 class="modal-title" id="questionnaireModalLabel">
            {{ isEditMode ? "Edit Questionnaire" : "Create Questionnaire" }}
          </h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" @click="onCancel"></button>
        </div>

        <!-- Modal Body -->
        <div class="modal-body">
          <form>
            <!-- Title Input -->
            <div class="mb-3">
              <label for="title" class="form-label">Title</label>
              <input
                v-model="questionnaire.title"
                type="text"
                class="form-control"
                id="title"
                placeholder="Enter title"
              />
            </div>

            <!-- Notes Input -->
            <div class="mb-3">
              <label for="notes" class="form-label">Notes</label>
              <textarea
                v-model="questionnaire.notes"
                class="form-control"
                id="notes"
                rows="2"
                placeholder="Enter notes"
              ></textarea>
            </div>

            <!-- Description Input -->
            <div class="mb-3">
              <label for="description" class="form-label">Description</label>
              <textarea
                v-model="questionnaire.description"
                class="form-control"
                id="description"
                rows="4"
                placeholder="Enter description"
              ></textarea>
            </div>
          </form>
        </div>

        <!-- Modal Footer -->
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" @click="onCancel">Cancel</button>
          <button type="button" class="btn btn-primary" @click="onSave">Save</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import * as bootstrap from "bootstrap";
import { defineComponent, onMounted, ref } from "vue";
import { useRouter } from "vue-router";
import { QuestionnaireAPI } from "../api/QuestionnaireApi";
import { Questionnaire } from "../models/models";

export default defineComponent({
  name: "QuestionnaireCreateEdit",
  props: {
    questionnaireId: {
      type: Number,
      required: false,
    },
  },
  setup(props) {
    const questionnaire = ref<Questionnaire>({
      id: 0,
      title: "",
      notes: "",
      description: "",
      questions: [],
      questionnaireRuns: [],
    });
    const isEditMode = ref(false);
    const router = useRouter();

    // Fetch the questionnaire if an ID is provided
    const fetchQuestionnaire = async () => {
      if (props.questionnaireId) {
        isEditMode.value = true;
        questionnaire.value = await QuestionnaireAPI.getQuestionnaireById(props.questionnaireId);
      }
    };

    // Handle cancel button
    const onCancel = () => {
      const modal = document.getElementById("questionnaireModal") as HTMLElement;
      const bsModal = bootstrap.Modal.getInstance(modal) || new bootstrap.Modal(modal);
      bsModal?.hide();
    };

    // Handle save button
    const onSave = async () => {
      const savedQuestionnaire = await QuestionnaireAPI.createQuestionnaire(questionnaire.value);
      const modal = document.getElementById("questionnaireModal") as HTMLElement;
      const bsModal = bootstrap.Modal.getInstance(modal) || new bootstrap.Modal(modal);
      bsModal?.hide();

      router.push(`/questionnaires/${savedQuestionnaire.id}`);
    };

    onMounted(() => {
      fetchQuestionnaire();
    });

    return {
      questionnaire,
      isEditMode,
      onCancel,
      onSave,
    };
  },
});
</script>

<style scoped>
.modal-content {
  border-radius: 10px;
  overflow: hidden;
}
</style>
