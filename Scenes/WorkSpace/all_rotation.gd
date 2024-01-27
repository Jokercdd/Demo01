extends CanvasLayer

@onready var v_scroll_bar: VScrollBar = $VScrollBar

func _ready() -> void:
	v_scroll_bar.value = 50
	
func _process(delta: float) -> void:
	caculate()
	
func caculate() -> void:
	var rot: float = (v_scroll_bar.value - 50) / 50 * PI
	$Goose.rotation = rot
