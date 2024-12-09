<template>
  <div class="modal fade" id="runDialog" tabindex="-1" aria-labelledby="modalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <!-- Modal Header -->
        <div class="modal-header">
          <h5 class="modal-title" id="modalLabel">Create New Questionnaire Run</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>

        <!-- Modal Body -->
        <div class="modal-body">
          <!-- Open DateTime -->
          <div class="mb-3">
            <label for="openDateTime" class="form-label">Open Date & Time</label>
            <input type="datetime-local" id="openDateTime" class="form-control" v-model="openDateTime" />
          </div>

          <!-- Close DateTime -->
          <div class="mb-3">
            <label for="closeDateTime" class="form-label">Close Date & Time</label>
            <input type="datetime-local" id="closeDateTime" class="form-control" v-model="closeDateTime" />
          </div>
        </div>

        <!-- Modal Footer -->
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
          <button type="button" class="btn btn-primary" @click="save">Save</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import * as bootstrap from "bootstrap";
import { defineComponent, ref } from "vue";
import { QuestionnaireAPI } from "../api/QuestionnaireApi";
import { QuestionnaireRun } from "../models/models";

export default defineComponent({
  name: "QuestionnaireRunCreate",
  props: {
    questionnaireId: {
      type: Number,
      required: true,
    },
  },
  setup(props) {
    const openDateTime = ref<string | null>(null);
    const closeDateTime = ref<string | null>(null);

    const save = async () => {
      if (!openDateTime.value || !closeDateTime.value) {
        alert("Please fill in both dates.");
        return;
      }

      // Convert string to Date for the API
      const openDate = new Date(openDateTime.value);
      const closeDate = new Date(closeDateTime.value);

      // Create the new QuestionnaireRun object
      const newRun: QuestionnaireRun = {
        id: 0,
        questionnaireId: props.questionnaireId,
        questionnaireRunStatus: 1, // Open
        createdAt: new Date(), // Current date in UTC
        openDateTime: openDate, // Converted to Date
        closeDateTime: closeDate, // Converted to Date
        answers: [],
      };

      // Call the API to save the new QuestionnaireRun
      await QuestionnaireAPI.createOrUpdateQuestionnaireRun(newRun);

      // Close the modal after saving
      const modalElement = document.getElementById("runDialog");
      if (modalElement) {
        const bootstrapModal = bootstrap.Modal.getInstance(modalElement);
        bootstrapModal?.hide();
      }
    };

    return {
      openDateTime,
      closeDateTime,
      save,
    };
  },
});
</script>

<style scoped>
.modal-header {
  background-color: #f8f9fa;
}
.modal-footer {
  border-top: 1px solid #dee2e6;
}
</style>
